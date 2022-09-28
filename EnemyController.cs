using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public Rigidbody2D theRB;
    public float moveSpeed;

    
    public float rangeToChasePlayer;
    private Vector3 moveDirection;

    public bool shouldChasePlayer;
    public bool shouldRunAway;
    public float runawayRange;

    public bool shouldWander;
    public float wanderLength, pauseLength;
    private float wanderCounter, pauseCounter;
    private Vector3 wanderDirection;

    public Animator anim;

    public int health = 150;

    public GameObject[] deathSplatters;
    public GameObject hitEffect;

    public bool shouldShoot;

    public GameObject bullet;
    public Transform firePoint;
    public float fireRate;
    private float fireCounter;

    public float shootRange;

    public GameObject[] bonePieces;
    public int maxPieces = 5;

    public SpriteRenderer theBody;

    // Start is called before the first frame update
    void Start()
    {
        if(shouldWander)
        {
            pauseCounter = Random.Range(pauseLength * .75f, pauseLength * 1.25f);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
        if(theBody.isVisible && PlayerController.instance.gameObject.activeInHierarchy)
        {

            moveDirection = Vector3.zero;

            if (Vector3.Distance(transform.position, PlayerController.instance.transform.position) < rangeToChasePlayer && shouldChasePlayer)
            {
                moveDirection = PlayerController.instance.transform.position - transform.position;

            } else
            {
                if(shouldWander)
                {
                    if(wanderCounter > 0)
                    {
                        wanderCounter -= Time.deltaTime;

                        moveDirection = wanderDirection;

                        if (wanderCounter <= 0)
                        {
                            pauseCounter = Random.Range(pauseLength * .75f, pauseLength * 1.25f);

                        }
                    }


                    if (pauseCounter > 0)
                    {
                        pauseCounter -= Time.deltaTime;

                        if(pauseCounter <= 0)
                        {
                            wanderCounter = Random.Range(wanderLength * .75f, wanderLength * 1.25f);

                            wanderDirection = new Vector3(Random.Range(-1f, 1f), Random.Range(-1f, 1f), 0f);
                        }

                    }
                
                }    
            }




            if(shouldRunAway && Vector3.Distance(transform.position, PlayerController.instance.transform.position) < runawayRange)
            {
                moveDirection = transform.position - PlayerController.instance.transform.position;
            }

            
           
            
            
            
            
            
            // else
            //{
            //    moveDirection = Vector3.zero;
            //}
            


            moveDirection.Normalize();

          

            theRB.velocity = moveDirection * moveSpeed;



            if (shouldShoot && Vector3.Distance(transform.position, PlayerController.instance.transform.position) < shootRange)
            {
                fireCounter -= Time.deltaTime;

                if (fireCounter <= 0)
                {
                    fireCounter = fireRate;
                    AudioManager.instance.PlaySFX(25);
                    Instantiate(bullet, firePoint.position, firePoint.rotation);
                }
            }

        }




        if (moveDirection != Vector3.zero)
        {
            anim.SetBool("isMoving", true);
        }
        else
        {
            anim.SetBool("isMoving", false);
        }

    }

    public void DamageEnemy(int damage)
    {
        health -= damage;

        Instantiate(hitEffect, transform.position, transform.rotation);

        if(health <= 0)
        {
            AudioManager.instance.PlaySFX(1);
            Destroy(gameObject);

            int selectedSplatter = Random.Range(0, deathSplatters.Length);

            int rotation = Random.Range(0, 4);

                Instantiate(deathSplatters[selectedSplatter], transform.position, Quaternion.Euler(0f, 0f, rotation * 90f));

            int bonesToDrop = Random.Range(3, maxPieces);

            for (int i = 0; i < bonesToDrop; i++)
            {
                int randombonePiece = Random.Range(0, bonePieces.Length);

                Instantiate(bonePieces[randombonePiece], transform.position, transform.rotation);
            }

            //Instantiate(deathSplatter, transform.position, transform.rotation);
        }

    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBullet : MonoBehaviour
{
    public float speed = 7.5f;
    public Rigidbody2D theRB;
    public GameObject impactEffect;
    public GameObject impactboxEffect;
    public int damageToGive = 50;


    //aboutbox 
    public GameObject[] brokenPieces;
    public int maxPieces = 5;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        theRB.velocity = transform.right * speed;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {

        if (other.tag == "Wall")
        {
            Instantiate(impactEffect, transform.position, transform.rotation);
            Destroy(gameObject);
        }
        if (other.tag == "Objects")
        {
            Instantiate(impactEffect, transform.position, transform.rotation);

            int piecesToDrop = Random.Range(3, maxPieces);

            for (int i = 0; i < piecesToDrop; i++)
            {


                int randomPiece = Random.Range(0, brokenPieces.Length);

                Instantiate(brokenPieces[randomPiece], other.transform.position, other.transform.rotation);



            }

            Destroy(other.gameObject);
            

            Destroy(gameObject);
        }


        if (other.tag == "Enemy")
        {
            other.GetComponent<EnemyController>().DamageEnemy(damageToGive);

            Instantiate(impactEffect, transform.position, transform.rotation);
            AudioManager.instance.PlaySFX(2);
            Destroy(gameObject);

        }

    }

   private void OnBecameInvisible()
    {
        Destroy(gameObject);

    }

}

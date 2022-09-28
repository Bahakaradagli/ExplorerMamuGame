using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    public GameObject enemybulletimpactEffect;
    public GameObject impactEffect;
    public float speed;
    private Vector3 direction;

    public GameObject[] brokenPieces;
    public int maxPieces = 5;


    void Start()
    {
        direction = PlayerController.instance.transform.position - transform.position;
            direction.Normalize();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += direction * speed * Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {

        if(other.tag == "Player")
        {
            Destroy(gameObject);
            PlayerHealthController.instance.DamagePlayer();
            Instantiate(impactEffect, transform.position, transform.rotation);
        }

        if (other.tag == "Wall")
        {
            Destroy(gameObject);
            Instantiate(enemybulletimpactEffect, transform.position, transform.rotation);
        }

        if (other.tag == "Objects")
        {

            int piecesToDrop = Random.Range(3, maxPieces);

            for (int i = 0; i < piecesToDrop; i++)
            {


                int randomPiece = Random.Range(0, brokenPieces.Length);

                Instantiate(brokenPieces[randomPiece], other.transform.position, other.transform.rotation);



            }
            Destroy(other.gameObject);
            Destroy(gameObject);
            Instantiate(enemybulletimpactEffect, transform.position, transform.rotation);
        }


    }
    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }

}

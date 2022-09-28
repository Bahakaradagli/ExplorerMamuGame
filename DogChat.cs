using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DogChat : MonoBehaviour
{
    public float waitForInactive;
    public GameObject DogChat1;
    
    // Start is called before the first frame update
    void Start()
    {
   
        DogChat1.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
  
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {

            DogChat1.SetActive(true);
          
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player")
        {


            DogChat1.SetActive(false);




        }
    }

}

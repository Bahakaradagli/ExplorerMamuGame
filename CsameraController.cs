using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CsameraController : MonoBehaviour
{
    public static CsameraController instance;
    
    public float moveSpeed;

    public Transform target;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
      
        if(target != null)
        {
            transform.position = Vector3.MoveTowards(transform.position, new Vector3(target.position.x, target.position.y, transform.position.z), moveSpeed * Time.deltaTime);

        }

    }
}

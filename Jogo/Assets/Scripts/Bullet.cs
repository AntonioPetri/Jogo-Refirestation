using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
   
    public Rigidbody rb;
    

    
    void Start()
    {
        rb.AddForce(transform.forward * 1000);
      
       ;
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.transform.tag == "enemy")
        {
            Destroy(this.gameObject);
        }
      
        
    }
}

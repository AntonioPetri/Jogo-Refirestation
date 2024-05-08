using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
   
    public Rigidbody rb;
    

    
    void Start()
    {
       rb.AddForce(transform.forward * 3000);     
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.transform.tag == "enemy" || other.transform.tag == "Enemy")
        {
            Destroy(this.gameObject);
        }
      
        
    }
}

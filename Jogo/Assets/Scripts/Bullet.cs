using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
   
    public Rigidbody rb;
    public GameObject Hit;
    public GameObject Fire;

    
    void Start()
    {
        rb.AddForce(transform.forward * 2000);
        GameObject A = Instantiate(Fire, this.transform.position, Quaternion.identity);
         Destroy(A, 2);
    }

    private void OnCollisionEnter(Collision other)
    {
        Debug.Log("passei aqui");
        GameObject B = Instantiate(Hit, this.transform.position, Quaternion.identity);
        Destroy(B, 2);
        Destroy(this.gameObject);
    }
}

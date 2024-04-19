using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class balacolisao : MonoBehaviour
{
    [SerializeField] private Vida vida;

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            other.GetComponent<Vida>().AplicarDano(10);
            Destroy(gameObject);
        }
    }
}

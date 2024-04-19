using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{

    public GameObject Bullet;
    public GameObject FirePosition;



    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            Shooting();
        }
    }

    public void Shooting()
    {
        Instantiate(Bullet, FirePosition.transform.position, FirePosition.transform.rotation);

    }


}

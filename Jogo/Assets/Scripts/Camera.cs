using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    internal static object main;
    public float sensX;
    private float sensY;
    

    public Transform orientation;

    float xRotation, yRotation;

    private void Start()
    {
        // Trava o cursor e deixa ele invisivel
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        sensX = PlayerPrefs.GetFloat("Sensibilidade");
        sensY = sensX;
        

    }
    private void Update()
    {
        // Coloca o movimento do mouse nos eixos certos, deixa ele a um estável fps e multiplica pela sens
        float mouseX = Input.GetAxisRaw("Mouse X") * Time.deltaTime * sensX;
        float mouseY = Input.GetAxisRaw("Mouse Y") * Time.deltaTime * sensY;

        // Trava com um limite para cima e para baixo
        yRotation += mouseX;
        xRotation -= mouseY;
        xRotation = Math.Clamp(xRotation, -90, 90);

        // Pega tudo e coloca na camera para ela mexer 
        transform.rotation = Quaternion.Euler(xRotation, yRotation, 0);
        orientation.rotation = Quaternion.Euler(0, yRotation, 0);     
    }
    
}

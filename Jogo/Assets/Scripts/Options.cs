using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class Options : MonoBehaviour
{

    public Slider Volume, Sensi;


    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChangeVolume(float volume)
    {
        Debug.Log(volume);
    }

    public void ChangeSensi(float sensi)
    {
        FindObjectOfType<Camera>().sensX = sensi;
        
    }
}

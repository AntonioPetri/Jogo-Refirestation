using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class Options : MonoBehaviour
{

    public Slider VolumeSlider, SensiSlider;
    public AudioMixer audioMixer;
    public float volumevalue;
    public float sensi;

    void Start()
    {
        VolumeSlider.value = PlayerPrefs.GetFloat("Volume");
        SensiSlider.value = PlayerPrefs.GetFloat("Sensibilidade");
    }

    void Update()
    {
        audioMixer.SetFloat("Volume", volumevalue);
        PlayerPrefs.SetFloat("Volume", volumevalue);
        PlayerPrefs.SetFloat("Sensibilidade", sensi);
    }

    public void ChangeVolume(float volume)
    {
        volumevalue = volume;
    }

    public void ChangeSensi(float sensibility)
    {
         sensi = sensibility;
    }
}

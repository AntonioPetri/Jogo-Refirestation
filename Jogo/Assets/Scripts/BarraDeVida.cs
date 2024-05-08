using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class BarraDeVida : MonoBehaviour
{
    [SerializeField]private Image BarraDeVidaImage;
    [SerializeField] TextMeshProUGUI HordaAtual;

    public void AlterarBarraDeVida(int vidaAtual, int VidaMaxima)
    {
        BarraDeVidaImage.fillAmount = (float)vidaAtual / VidaMaxima;
    }

    private void Update()
    {
        HordaAtual.text = $"Horda: {FindObjectOfType<WaveSpawner>().Horda}";
    }


}

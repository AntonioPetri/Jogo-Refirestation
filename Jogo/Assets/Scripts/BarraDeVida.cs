using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class BarraDeVida : MonoBehaviour
{
    [SerializeField]private Image BarraDeVidaImage;

    public void AlterarBarraDeVida(int vidaAtual, int VidaMaxima)
    {
        BarraDeVidaImage.fillAmount = (float)vidaAtual / VidaMaxima;
    }

}

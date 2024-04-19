using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vida: MonoBehaviour
{
    public int vidaAtual;
    private int vidaTotal = 100;
    [SerializeField] private BarraDeVida barraDeVida;
    [SerializeField] private Menu menu;

    void Start()
    {
        vidaAtual = vidaTotal;

        barraDeVida.AlterarBarraDeVida(vidaAtual, vidaTotal);
    }
    private void Update()
    {
        if (vidaAtual <= 0)
        {

        }
    }

    public void AplicarDano (int dano)
    {
        vidaAtual -= 10;
        barraDeVida.AlterarBarraDeVida(vidaAtual, vidaTotal);
    }


}

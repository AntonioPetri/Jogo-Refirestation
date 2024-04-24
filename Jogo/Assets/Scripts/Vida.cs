using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vida: MonoBehaviour
{
    public int vidaAtual = 100;
    public int vidaTotal = 100;
    [SerializeField] private BarraDeVida barraDeVida;
    [SerializeField] private Menu menu;
    public bool Morto = false;

    void Start()
    {
        vidaAtual = vidaTotal;

        barraDeVida.AlterarBarraDeVida(vidaAtual, vidaTotal);
    }
    private void Update()
    {
        Console.WriteLine(Morto);
    }


    public void AplicarDano (int dano)
    {
        vidaAtual -= 10;
        barraDeVida.AlterarBarraDeVida(vidaAtual, vidaTotal);
        if (vidaAtual <= 0)
        {
            Morto = true;
        }
    }



}

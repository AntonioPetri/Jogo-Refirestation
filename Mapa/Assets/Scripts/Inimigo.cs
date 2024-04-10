using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inimigo : MonoBehaviour
{
    public float speed = 3f; // Velocidade de movimento do inimigo
    public float stoppingDistance = 2f; // Distância de parada para começar a perseguir o jogador
    private Transform target; // Referência ao transform do jogador

    void Start()
    {
        // Encontrar o transform do jogador
        target = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update()
    {
        // Verificar se o jogador existe
        if (target == null)
        {
            Debug.LogWarning("Player not found!");
            return;
        }

        // Verificar a distância entre o inimigo e o jogador
        float distanceToTarget = Vector3.Distance(transform.position, target.position);

        // Se a distância for maior que a distância de parada, seguir o jogador
        if (distanceToTarget > stoppingDistance)
        {
            // Calcular a direção para o jogador
            Vector3 direction = (target.position - transform.position).normalized;

            // Mover o inimigo na direção do jogador
            transform.position += direction * speed * Time.deltaTime;

            // Ajustar a rotação para olhar na direção do jogador (opcional)
            transform.LookAt(target);
        }
    }
}
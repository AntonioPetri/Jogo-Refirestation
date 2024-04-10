using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inimigo : MonoBehaviour
{
    public float speed = 3f; // Velocidade de movimento do inimigo
    public float stoppingDistance = 2f; // Dist�ncia de parada para come�ar a perseguir o jogador
    private Transform target; // Refer�ncia ao transform do jogador

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

        // Verificar a dist�ncia entre o inimigo e o jogador
        float distanceToTarget = Vector3.Distance(transform.position, target.position);

        // Se a dist�ncia for maior que a dist�ncia de parada, seguir o jogador
        if (distanceToTarget > stoppingDistance)
        {
            // Calcular a dire��o para o jogador
            Vector3 direction = (target.position - transform.position).normalized;

            // Mover o inimigo na dire��o do jogador
            transform.position += direction * speed * Time.deltaTime;

            // Ajustar a rota��o para olhar na dire��o do jogador (opcional)
            transform.LookAt(target);
        }
    }
}
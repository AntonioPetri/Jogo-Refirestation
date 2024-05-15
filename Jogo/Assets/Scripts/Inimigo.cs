using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inimigo : MonoBehaviour
{
    public float speed = 3f; // Velocidade de movimento do inimigo
    public float stoppingDistance = 2f; // Distancia de parada para comecar a perseguir o jogador
    private Transform target; // Referencia ao transform do jogador
    public int vidaInimigo = 10;
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

        // Verificar a distancia entre o inimigo e o jogador
        float distanceToTarget = Vector3.Distance(transform.position, target.position);

        // Se a distancia for maior que a distancia de parada, seguir o jogador
        if (distanceToTarget > stoppingDistance)
        {
            // Calcular a direcao para o jogador
            Vector3 direction = (target.position - transform.position).normalized;

            // Mover o inimigo na direcao do jogador
            transform.position += direction * speed * Time.deltaTime;

            // Ajustar a rotacao para olhar na direcao do jogador (opcional)
            transform.LookAt(target);
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.transform.tag == "Bullet")
        {
            vidaInimigo -= 10;
        }
        if (vidaInimigo<= 0)
        {
            Destroy(this.gameObject);
        }
    }
}
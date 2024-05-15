using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bala1 : MonoBehaviour
{
    public UnityEngine.AI.NavMeshAgent enemy;
    //Referencia ao Transform do jogador (para saber a posicao do alvo)
    public Transform player;

    //Timer para controlar o intervalo entre disparos
    [SerializeField] private float timer = 5;
    private float bulletTime;

    //Prefab da bala inimiga e ponto de spawn da bala
    public GameObject enemyBullet;
    public Transform spawnPoint;
    //Velocidade da bala inimiga
    public float enemySpeed;

    // Start e chamado antes da primeira atualizacao do frame
    void Start()
    {
        
    }

    // Update e chamado uma vez por frame
    void Update()
    {
        //Chama a funcao que controla o disparo no jogador
        ShootAtPlayer();
    }

    
    //Funcao que controla o disparo no jogador
    void ShootAtPlayer()
    {
        //Diminui o bulletTime conforme o tempo passa
        bulletTime -= Time.deltaTime;
        //Se bulletTime ainda for maior q 0, retorna sem faze nada
        if (bulletTime > 0) return;

        //Reseta o bulletT.. para o valor  do timer
        bulletTime = timer;

        //Instancia um novo objeto bala na posicao e rotacao do spawnpoint
        GameObject bulletObj = Instantiate(enemyBullet, spawnPoint.transform.position, spawnPoint.transform.rotation) as GameObject;
        //Obtem o componente Rigidbody da bala para aplicar a forca
        Rigidbody bulletRig = bulletObj.GetComponent<Rigidbody>();
        //Adiciona uma forca a bala na direcao para frente multiplicada pela velocidade
        bulletRig.AddForce(bulletRig.transform.forward * enemySpeed);
        //Destroi a bala dps de 5s
        Destroy(bulletObj, 5f);
    }

}

using UnityEngine;
using System.Collections;


public class WaveSpawner : MonoBehaviour 
{

    //Enum para definir o estado de spawn
    public enum SpawnState{ SPAWNING, WAITING, COUNTING };

    //Classe para definir uma wave
    [System.Serializable]
    public class Wave
    {
        public string name;     //Nome da wave
        public Transform enemy; //Inimigo a ser spawnado
        public int count;       //Numero de inimigos na onda
        public float rate;      //Taxa de spawn de  inimigos
    }

    public Wave[] waves;      //Array de ondas
    private int nextWave = 0; //Indice da proxima onda a ser spawnada

    public Transform[] spawnPoints;     //Array de pontos de spawn para os inimigos

    public float timeBetweenWaves = 5f; //tempo entre cada onda
    private float waveCountdown;        //Contagem regressiva para o proxima onda

    private float searchCountdown = 1f; //Contagem regressiva para procurar inimigos

    private SpawnState state = SpawnState.COUNTING; //Estado inicial, contando

    public float Horda = 1; //Variavel para rasrtear o numero da onda
    void Start()
    {
        //Verificar se os pontos de spawn foram referenciados
        if (spawnPoints.Length == 0)
        {
            Debug.LogError("No spawn points referenced.");
        }
        //Inicializar contagem regressiva da onda
        waveCountdown = timeBetweenWaves;
    }

    void Update()
    {
        //Verificar se esta esperando a conclusao da onda
        if (state == SpawnState.WAITING)
        {
            //Verificar se todos os inimigos foram derrotados
            if(!EnemyIsAlive())
            {
                //Comecar uma nova rodada
               WaveCompleted();
               
            } 
            else
            {
                return;
            }
        }
        //Verificar se e hora de spawnar uma nova wave
        if(waveCountdown <= 0)
        {
            if (state != SpawnState.SPAWNING)
            {
                StartCoroutine( SpawnWave (waves[nextWave]));
            }
        }
        else
        {
                waveCountdown -= Time.deltaTime;
        }
    }

    void WaveCompleted()
    {
        Debug.Log("Wave Completed");

        //Definir estado para "contando" e resetar contagem regressiva da onda
        state = SpawnState.COUNTING;
        waveCountdown = timeBetweenWaves;

        //Mover para a proxima onda, ou reiniciar se todas as ondas estiverem completas
        if(nextWave + 1 > waves.Length - 1)
        {
            nextWave = 0;
            Debug.Log ("ALL WAVES COMPLETE! Looping...");
        }
        else
        {
            nextWave ++;
        }
        //Incrementar numero da onda
        Horda++;
    }

    bool EnemyIsAlive()
    {
        //Reduz o tempo de contagem regressiva de busca
        searchCountdown -= Time.deltaTime;
        // Verifica se ha inimigos vivos
        if(searchCountdown <= 0f)
        {
            //Reseta a contagem regressiva para 1 segundo
            searchCountdown = 1f;

            //Se nenhum GameObject com a tag  de enemy for encontrado, retorna verdadeiro
            if (GameObject.FindGameObjectWithTag("Enemy") == null)
            {
                return false;
            }
        }
        return true;
    }

    IEnumerator SpawnWave(Wave _wave)
    {
        Debug.Log ("Spawning Wave:" + _wave.name);

        //Define o estado para spawning
        state = SpawnState.SPAWNING;

        //Loop para spawnar inimigos de acordo com a quantidade definida na onda
        for (int i = 0; i< _wave.count; i++)
        {
            //Chama o metodo de SpawnEnemy para spawnar o inimigo
            SpawnEnemy(_wave.enemy);

            //Espera um intervalo baseado na taxa de spawn definida na onda
           yield return new WaitForSeconds(1f/_wave.rate);
        }
        //Apos spawnar , defino o estado para waiting
        state = SpawnState.WAITING;

        yield break;
    
    }
    void SpawnEnemy (Transform _enemy)
    {
        Debug.Log("Spawning Enemy: " + _enemy.name);
        //Seleciona aleatoriamente um ponto de spawn 
        Transform _sp = spawnPoints[ Random.Range(0, spawnPoints.Length)];
        //Instancia o inimigo na posicao e rotacao de ponto de spawn selecionado
        Instantiate (_enemy, _sp.position, _sp.rotation);
    }
}


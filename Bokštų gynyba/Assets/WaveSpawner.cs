using System.Collections;
using UnityEngine;

public class WaveSpawner : MonoBehaviour
{
    public GameObject errorMsgs;
    public Transform enemyPrefab;
    public Transform[] prefabs;
    public int[] enemyPrices;
    public Transform spawner;

    public Transform spawnerP2;

    private Player player2;

    public float waveTimer = 5f;
    public float countDown = 2f;
    public float timeBetweenEnemies = 0.5f;
    public int waveNumber = 1;
    public Player player;

    public Enemy k;
    private HeyImWalkingHere kk;

    private void Start()
    {
        player = this.GetComponent<Player>();
        player2 = spawnerP2.GetComponent<Player>();
    }

    void Update()
    {
        if (countDown <= 0)
        {
            StartCoroutine(SpawnWave());
            countDown = waveTimer + waveNumber*1.56f;
        }
        else
            countDown -= Time.deltaTime;
    }

    IEnumerator SpawnWave ()
    {
        waveNumber++;
        if (waveNumber <= 2)
        {
            for (int i = 0; i < waveNumber + 1; i++)
            {
                SpawnEnemy(0);
                yield return new WaitForSeconds(timeBetweenEnemies);
            }
        }
        else if (waveNumber <= 4)
        {
            for (int i = 0; i < waveNumber +1 ; i++)
            {
                SpawnEnemy(0);
                yield return new WaitForSeconds(timeBetweenEnemies);
            }
            for (int i = 0; i < waveNumber - 2; i++)
            {
                SpawnEnemy(1);
                yield return new WaitForSeconds(timeBetweenEnemies);
            }
        }
        else if(waveNumber <= 6)
        {
            for (int i = 0; i < waveNumber; i++)
            {
                SpawnEnemy(0);
                yield return new WaitForSeconds(timeBetweenEnemies);
            }
            for (int i = 0; i < waveNumber - 3; i++)
            {
                SpawnEnemy(1);
                yield return new WaitForSeconds(timeBetweenEnemies);
            }
            for (int i = 0; i < waveNumber - 4; i++)
            {
                SpawnEnemy(2);
                yield return new WaitForSeconds(timeBetweenEnemies);
            }
        }
        else if(waveNumber <= 8)
        {
            for (int i = 0; i < waveNumber - 1; i++)
            {
                SpawnEnemy(0);
                yield return new WaitForSeconds(timeBetweenEnemies);
            }
            for (int i = 0; i < waveNumber - 3; i++)
            {
                SpawnEnemy(1);
                yield return new WaitForSeconds(timeBetweenEnemies);
            }
            for (int i = 0; i < waveNumber - 4; i++)
            {
                SpawnEnemy(2);
                yield return new WaitForSeconds(timeBetweenEnemies);
            }
            for (int i = 0; i < waveNumber - 5; i++)
            {
                SpawnEnemy(3);
                yield return new WaitForSeconds(timeBetweenEnemies);
            }
        }
        else
        {
            for (int i = 0; i < waveNumber -2; i++)
            {
                SpawnEnemy(0);
                yield return new WaitForSeconds(timeBetweenEnemies);
            }
            for (int i = 0; i < waveNumber - 2; i++)
            {
                SpawnEnemy(1);
                yield return new WaitForSeconds(timeBetweenEnemies);
            }
            for (int i = 0; i < waveNumber - 3; i++)
            {
                SpawnEnemy(2);
                yield return new WaitForSeconds(timeBetweenEnemies);
            }
            for (int i = 0; i < waveNumber -4; i++)
            {
                SpawnEnemy(3);
                yield return new WaitForSeconds(timeBetweenEnemies);
            }
            for (int i = 0; i < waveNumber -6; i++)
            {
                SpawnEnemy(4);
                yield return new WaitForSeconds(timeBetweenEnemies);
            }
        }

        //for (int i = 0; i < waveNumber; i++)
        //{
        //    SpawnEnemy(0);
        //    yield return new WaitForSeconds(timeBetweenEnemies);
        //}
        //for (int i = 0; i < waveNumber - 1; i++)
        //{
        //    SpawnEnemy(1);
        //    yield return new WaitForSeconds(timeBetweenEnemies);
        //}
        //for (int i = 0; i < waveNumber - 2; i++)
        //{
        //    SpawnEnemy(2);
        //    yield return new WaitForSeconds(timeBetweenEnemies);
        //}
        //for (int i = 0; i < waveNumber - 3; i++)
        //{
        //    SpawnEnemy(3);
        //    yield return new WaitForSeconds(timeBetweenEnemies);
        //}
        //for (int i = 0; i < waveNumber; i++)
        //{
        //    SpawnEnemy(4);
        //    yield return new WaitForSeconds(timeBetweenEnemies);
        //}
    }

    void SpawnEnemy(int enemyNumber)
    {
        Transform enemy;
        enemy = Instantiate(prefabs[enemyNumber], new Vector3(spawner.position.x, spawner.position.y - 7.5f, spawner.position.z), spawner.rotation);
        k = enemy.GetComponent<Enemy>();
        k.getPlayer(player);
        kk = enemy.GetComponent<HeyImWalkingHere>();
        kk.getPlayer(player);
    }

    public void BuyEnemy(int enemyNumber)
    {
        if (player.money >= enemyPrices[enemyNumber])
        {
            Transform enemy;
            enemy = Instantiate(prefabs[enemyNumber], spawnerP2.position, spawnerP2.rotation);
            k = enemy.GetComponent<Enemy>();
            k.getPlayer(player2);
            kk = enemy.GetComponent<HeyImWalkingHere>();
            kk.getPlayer(player2);
            player.incomeMoney(-enemyPrices[enemyNumber]);
        }
        else
        {
            errorMsgScript errMsg = errorMsgs.GetComponent<errorMsgScript>();
            errMsg.NotEnoughMoney();
            Debug.Log("neuzteko pinigu fermai");
        }
    }

}

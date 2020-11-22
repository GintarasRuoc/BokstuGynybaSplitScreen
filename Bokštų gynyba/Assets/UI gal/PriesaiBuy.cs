using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PriesaiBuy : MonoBehaviour
{
    public GameObject spawner;
    private Player p;
    private movement m;
    private WaveSpawner ws;

    private void Start()
    {
        p = spawner.GetComponent<Player>();
        ws = spawner.GetComponent<WaveSpawner>();
    }

    public void SendEnemy(int enemyNumber)
    {
        ws.BuyEnemy(enemyNumber);
    }

}

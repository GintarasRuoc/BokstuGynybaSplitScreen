using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Bokstas1P : MonoBehaviour
{
    public GameObject spawner;
    private Player p;
    public GameObject tiles;
    private movement m;

    private void Start()
    {
        p = spawner.GetComponent<Player>();
        m = tiles.GetComponent<movement>();
    }

    public void BuildTower(int number)
    {
            m.BuildMeniu(number);
    }
}

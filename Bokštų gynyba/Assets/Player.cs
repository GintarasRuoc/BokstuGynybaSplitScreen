using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    public int hp = 100;
    public int money = 0;

    public void lastWaypoint()
    {
        hp--;
        if (hp <= 0)
            Debug.Log("Player lost");
    }

    public void incomeMoney(int income)
    {
        money += income;
    }

}

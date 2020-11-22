using UnityEngine;

public class Player : MonoBehaviour
{

    public int hp = 2;
    int money;
    int income;

    public void lastWaypoint()
    {
        hp--;
        if (hp <= 0)
            Debug.Log("Player lost");
    }

    public void getIncome(int m)
    {
        money = m;
    }
}

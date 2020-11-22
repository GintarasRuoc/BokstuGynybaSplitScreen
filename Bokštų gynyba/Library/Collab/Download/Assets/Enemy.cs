using UnityEngine;

public class Enemy:MonoBehaviour
{

    public int health = 1;
    public int deathIncome = 10;

    public void takeDamage(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            Destroy(gameObject);
        }

    }
    
}

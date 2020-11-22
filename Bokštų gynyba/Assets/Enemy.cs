using UnityEngine;

public class Enemy:MonoBehaviour
{

    public int health = 1;
    public int deathIncome = 10;
    public Player player;

    public void takeDamage(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            player.incomeMoney(deathIncome);
            Destroy(gameObject);
        }

    }

    public void getPlayer(Player play)
    {
        player = play;
    }
    
}

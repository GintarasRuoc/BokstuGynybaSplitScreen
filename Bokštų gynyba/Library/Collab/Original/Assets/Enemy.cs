using UnityEngine;

public class Enemy:MonoBehaviour
{

    public string name = "Warrior";
    public int health = 1;
    public int income = 10;

    public GameObject player;
    public string playerTag = "Player";
    public string player2Tag = "Player";

    public void takeDamage(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            Destroy(gameObject);
            Player person = player.GetComponent<Player>();

            person.getIncome(income);
        }

    }

    void GetPlayer()
    {
        if (transform.position.x < 1000f)
            player = GameObject.FindGameObjectWithTag(playerTag);
        else
            player = GameObject.FindGameObjectWithTag(player2Tag);
    }

}

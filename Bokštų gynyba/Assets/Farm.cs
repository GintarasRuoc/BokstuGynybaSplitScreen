using UnityEngine;

public class Farm : MonoBehaviour
{
    [Header("Stats")]
    public int income = 50;
    public float incomeSpeed = 1f;
    public float incomeCountdown = 1f;
    public int sell = 50;
    public int price = 5;
    public Player p;

    public GameObject player;

    [Header("Upgrade 1")]
    public bool upgradeOne = false;
    public int upgradeOneCost = 200;
    public GameObject upgradedBuilding;

    private Tile tile;

    private void Update()
    {
        if(incomeCountdown <= 0f)
        {
            p.incomeMoney(income);
            incomeCountdown = 1f / incomeSpeed;
        }

        incomeCountdown -= Time.deltaTime;
    }

    public void upgradeFarmOne(UpgradeUIScript f)
    {
        GameObject k = Instantiate(upgradedBuilding, gameObject.transform.position, gameObject.transform.rotation);
        Farm farm = k.GetComponent<Farm>();
        farm.upgradeOne = true;
        p.incomeMoney(-upgradeOneCost);
        farm.getPlayer(p, tile);
        Destroy(gameObject);

        f.idk(k);
    }

    public void sellFarm()
    {
        p.incomeMoney(sell);
        Destroy(this.gameObject);
        tile.hasBuilding = false;
    }

    public void getPlayer(Player play, Tile location)
    {
        p = play;
        tile = location;
    }
}

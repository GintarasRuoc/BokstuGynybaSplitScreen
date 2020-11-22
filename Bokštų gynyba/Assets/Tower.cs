using System.Collections;
using UnityEngine;

public class Tower : MonoBehaviour
{
    public Player player;

    [Header("Stats")]
    public int price = 5;
    public int damage = 1;
    public int sell = 50;
    public float attackSpeed = 1f;
    public float range = 15f;
    // true jeigu daro 1, false jeigu daro aplinkui zala
    public bool aoe = true;
    public float aoeRange = 100f;

    //public Transform target;
    [Header("Enemy")]
    public GameObject target;
    public string enemyTag = "Enemy";
    private float attackCountDown = 0f;

    [Header("Bullet stuff")]
    public GameObject bulletPrefab;
    public Transform firePoint;

    [Header("Upgrade 1")]
    public bool upgradeOne = false;
    public int upgradeOneCost = 200;
    public int upgradeOneDamage = 10;
    public float upgradeOneSpeed = 1f;
    public float upgradeOneRange = 2f;
    public int upgradeOneSell = 50;

    [Header("Upgrade 2")]
    public bool upgradeTwo = false;
    public int upgradeTwoCost = 240;
    public int upgradeTwoDamage = 20;
    public float upgradeTwoSpeed = 0.5f;
    public float upgradeTwoRange = 2f;
    public int upgradeTwoSell = 100;

    private Tile tile;


    void Start()
    {
        InvokeRepeating("ClosestTarget", 0f, 0.5f);
    }

    void ClosestTarget()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag(enemyTag);
        float shortestDistance = Mathf.Infinity;
        GameObject nearestEnemy = null;
        foreach (GameObject enemy in enemies)
        {
            float distance = Vector3.Distance(transform.position, enemy.transform.position);
            if (distance < shortestDistance)
            {
                nearestEnemy = enemy;
                shortestDistance = distance;
            }
        }

        if(shortestDistance <= range && nearestEnemy != null)
        {
            target = nearestEnemy;
            //Debug.Log("Radau");
        }
        else
        {
            target = null;
        }
    }

    private void Update()
    {
        if (target == null)
            return;

        if(attackCountDown <= 0f)
        {
            shoot();
            attackCountDown = 1f / attackSpeed;
        }

        attackCountDown -= Time.deltaTime;
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, range);
    }

    void shoot()
    {
        GameObject bulletGO = (GameObject) Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Bullet bullet = bulletGO.GetComponent<Bullet>();

        if (bullet != null)
            bullet.getInfo(target, damage, aoe, aoeRange);
    }

    public void upgradeTowerOne()
    {
        upgradeOne = true;
        damage += upgradeOneDamage;
        attackSpeed += upgradeOneSpeed;
        range += upgradeOneRange;
        sell += upgradeOneSell;
        player.incomeMoney(-upgradeOneCost);
    }

    public void upgradeTowerTwo()
    {
        upgradeTwo = true;
        damage += upgradeTwoDamage;
        attackSpeed += upgradeTwoSpeed;
        range += upgradeTwoRange;
        sell += upgradeTwoSell;
        player.incomeMoney(-upgradeTwoCost);
    }

    public void sellTower()
    {
        player.incomeMoney(sell);
        Destroy(this.gameObject);
        tile.hasBuilding = false;
    }

    public void getPlayer(Player play, Tile location)
    {
        player = play;
        tile = location;
    }
}
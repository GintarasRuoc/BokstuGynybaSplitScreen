using UnityEngine;

public class Bullet : MonoBehaviour
{

    private GameObject target;
    private int towerDamage;
    private bool aoe;
    private float aoeRange;

    public float speed = 70f;

    public void getInfo(GameObject enemy, int damage, bool type, float range)
    {
        target = enemy;
        towerDamage = damage;
        aoe = type;
        aoeRange = range;
    }

    // Update is called once per frame
    void Update()
    {
        if(target == null)
        {
            Destroy(gameObject);
            return;
        }
        Vector3 dir = target.transform.position - transform.position;
        float distanceThisFrame = speed * Time.deltaTime;

        if(dir.magnitude <= distanceThisFrame)
        {
            if (aoe)
                AoeHitTarget();
            else HitTarget();
            return;
        }

        transform.Translate(dir.normalized * distanceThisFrame, Space.World);

    }

    void HitTarget()
    {
        Enemy enemy = target.GetComponent<Enemy>();
        enemy.takeDamage(towerDamage);

        Destroy(gameObject);
    }

    void AoeHitTarget()
    {
        GameObject k;
        Collider[] colliders;
        Vector3 find = target.transform.position;
        colliders = Physics.OverlapSphere(find, aoeRange);
        Debug.Log(colliders.Length);
        foreach (Collider col in colliders)
        {
            Debug.Log(col.name);
            Enemy enemy = col.GetComponent<Enemy>();
            if (enemy != null)
            {
                enemy.takeDamage(towerDamage);
            }
        }
        Destroy(gameObject);
    }
}

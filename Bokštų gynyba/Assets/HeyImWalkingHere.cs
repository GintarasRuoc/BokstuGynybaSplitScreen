using UnityEngine;

public class HeyImWalkingHere : MonoBehaviour {

    public float speed = 10f;

    private Transform target;
    private int wayPointIndex = 0;
    private Player player;
    public Waypoints waypoint;
    public float turnSpeed = 5f;

    private void Start()
    {
        GameObject[] objects = GameObject.FindGameObjectsWithTag(player.tag);
        foreach (GameObject way in objects)
        {
            waypoint = way.GetComponent<Waypoints>();
            if (waypoint != null)
            {
                target = waypoint.points[0];
                break;
            }
        }
    }

    private void Update()
    {
        Vector3 dir = target.position - transform.position;
        transform.Translate(dir.normalized * speed * Time.deltaTime, Space.World);
        Quaternion lookRotation = Quaternion.LookRotation(dir);
        Vector3 rotation = Quaternion.Lerp(transform.rotation, lookRotation, Time.deltaTime * turnSpeed).eulerAngles;
        transform.rotation = Quaternion.Euler(0f, rotation.y, 0f);

        if (Vector3.Distance(transform.position, target.position) <= 0.4f)
            GetNextWaypoint();
    }

    void GetNextWaypoint()
    {
        if (wayPointIndex >= waypoint.points.Length - 1)
        {
            player.lastWaypoint();
            Destroy(gameObject);
        }
        else
        {
            wayPointIndex++;
            target = waypoint.points[wayPointIndex];
        }
    }

    public void getPlayer(Player play)
    {
        player = play;
    }
}

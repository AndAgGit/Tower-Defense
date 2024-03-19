using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float speed;

    private Transform target;
    private int waypointIndex = 0;
    private float distance;

    private void Awake()
    {
        target = Waypoints.waypoints[0];
        distance = Random.Range(0.1f, 3f);
    }
    void Update()
    {
        transform.LookAt(target);
        transform.Translate(speed * Time.deltaTime * transform.forward, Space.World);

        if(Vector3.Distance(transform.position, target.position) <= distance)
        {
            GetNextWaypoint();
        }
    }

    private void GetNextWaypoint()
    {
        if(waypointIndex >= Waypoints.waypoints.Length - 1)
        {
            Destroy(gameObject);
            return;
        }

        waypointIndex++;
        target = Waypoints.waypoints[waypointIndex];
    }
}

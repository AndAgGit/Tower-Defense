using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    private Enemy enemy;
    private Transform target;
    private int waypointIndex = 0;
    private float distance;

    private void Awake()
    {
        enemy = GetComponent<Enemy>();
        target = Waypoints.waypoints[0];
        distance = Random.Range(0.1f, 3f);
    }
    void Update()
    {
        transform.LookAt(target);
        transform.Translate(enemy.speed * Time.deltaTime * transform.forward, Space.World);

        if (Vector3.Distance(transform.position, target.position) <= distance)
        {
            GetNextWaypoint();
        }

        enemy.speed = enemy.baseSpeed;
    }

    private void GetNextWaypoint()
    {
        if (waypointIndex >= Waypoints.waypoints.Length - 1)
        {
            PathEnd();
            return;
        }

        waypointIndex++;
        target = Waypoints.waypoints[waypointIndex];
    }

    void PathEnd()
    {
        Destroy(gameObject);
        PlayerStats.lives--;
        WaveSpawner.enemiesAlive--;
    }

    
}

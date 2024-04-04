using Unity.VisualScripting;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float speed;
    public int health = 100;
    public int value = 1;
    public GameObject deathEffect;

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
            PathEnd();
            return;
        }

        waypointIndex++;
        target = Waypoints.waypoints[waypointIndex];
    }

    void PathEnd(){
        Destroy(gameObject);
        PlayerStats.lives--;
    }

    public void TakeDamage(int amount){
        health -= amount;
        if (health <= 0){
            Die();
        }
    }

    private void Die(){
        GameObject effect = Instantiate(deathEffect, transform.position, Quaternion.identity);
        Destroy(effect, 5);
        Destroy(gameObject);
        PlayerStats.money += value;
    }
}

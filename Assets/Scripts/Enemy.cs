using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    public float baseSpeed = 5f;
    public float maxHealth = 100f;
    private float health;
    public int value = 1;
    

    [Header("Splitter")]
    public bool isSplitter;
    public GameObject babyPrefab;

    [HideInInspector]
    public float speed =  5f;
    
    [Header("Unity Setup")]
    public Image healthBar;
    public GameObject deathEffect;

    void Start()
    {
        speed = baseSpeed;
        health = maxHealth;
    }

    public void TakeDamage(float amount){
        health -= amount;
        healthBar.fillAmount = health / maxHealth;
        if (health <= 0){
            Die();
        }
    }

    private void Die(){
        GameObject effect = Instantiate(deathEffect, transform.position, Quaternion.identity);
        Destroy(effect, 5);
        
        PlayerStats.money += value;
        WaveSpawner.enemiesAlive--;

        if (isSplitter)
        {
            SpawnBabies();
        }

        Destroy(gameObject);
    }

    private void SpawnBabies()
    {
        int waypointIndex = GetComponent<EnemyMovement>().GetWayPointIndex();

        GameObject baby = Instantiate(babyPrefab, transform.position + Vector3.right, Quaternion.identity);
        baby.GetComponent<EnemyMovement>().SetWayPointIndex(waypointIndex);
        WaveSpawner.enemiesAlive++;

        baby = Instantiate(babyPrefab, transform.position + Vector3.left, Quaternion.identity);
        baby.GetComponent<EnemyMovement>().SetWayPointIndex(waypointIndex);
        WaveSpawner.enemiesAlive++;
    }

    public void SpeedMod(float percentage)
    {
        speed = baseSpeed * (1f - percentage);
    }
}

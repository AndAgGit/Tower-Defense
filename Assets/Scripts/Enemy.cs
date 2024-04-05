using Unity.VisualScripting;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float baseSpeed = 5f;
    [HideInInspector]
    public float speed =  5f;

    public float health = 100;
    public int value = 1;
    public GameObject deathEffect;

    void Start()
    {
        speed = baseSpeed;
    }

    public void TakeDamage(float amount){
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

    public void SpeedMod(float percentage)
    {
        speed = baseSpeed * (1f - percentage);
    }
}

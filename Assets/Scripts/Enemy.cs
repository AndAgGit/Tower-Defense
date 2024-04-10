using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    public float baseSpeed = 5f;

    [HideInInspector]
    public float speed =  5f;

    public float maxHealth = 100f;
    private float health;
    public int value = 1;
    public GameObject deathEffect;

    [Header("Unity Setup")]
    public Image healthBar;

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
        Destroy(gameObject);
        PlayerStats.money += value;
    }

    public void SpeedMod(float percentage)
    {
        speed = baseSpeed * (1f - percentage);
    }
}

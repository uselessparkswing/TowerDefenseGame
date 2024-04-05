using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    public float startSpeed = 10f;

    [HideInInspector]
    public float speed;

    public float startHealth = 100;
    private float health;

    public int moneyValue = 50;

    public GameObject enemyDeathEffect;

    [Header("Unity Stuff")]
    public Image healthBar;

    private bool isDead = false;

    private void Start()
    {
        speed = startSpeed;
        health = startHealth;
    }

    public void takeDamage(float damage)
    {
        health -= damage;

        healthBar.fillAmount = health / startHealth;

        if (health <= 0 && !isDead)
        {
            Die();
        }
    }

    public void Slow(float percentage)
    {
        speed = startSpeed * (1f - percentage);
    }

    void Die()
    {
        isDead = true;
        PlayerStats.money += moneyValue;

        GameObject deathEffect = (GameObject)Instantiate(enemyDeathEffect, transform.position, Quaternion.identity);
        Destroy(deathEffect, 5f);

        WaveSpawner.enemiesAlive--;

        Destroy(gameObject);
    }
}

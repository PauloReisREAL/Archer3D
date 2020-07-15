using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStats : MonoBehaviour
{
    public int health;
    private int maxHP;
    private EnemyManager enemyManager;
    public GaugeUpdater healthGauge;

    private void Start()
    {
        maxHP = health;
        enemyManager = GameObject.FindObjectOfType<EnemyManager>();

    }
    public void Hit (int damage)
    {
        health -= damage;
        Debug.Log("Enemy Health: " + health.ToString());
        healthGauge.UpdateGauge(health, maxHP);
    }

    void Update()
    {
        if(health <= 0)
        {
            enemyManager.RegisterEnemiesKilled();
            Destroy(gameObject);
        }
    }
}

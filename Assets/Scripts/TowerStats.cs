using UnityEngine;
using System.Collections;
using UnityEngine.Events;

public class TowerStats : MonoBehaviour
{
    public int maxHP;
    public int health;
    public bool isHit;
    public UnityEvent onGameOver;
    public GaugeUpdater healthGauge;

    private void Start()
    {
        maxHP = health;
    }
    void Update()
    {
        if (health <= 0)
        {
            onGameOver.Invoke();
            Debug.Log("Dead");
        }
    }

    public void Hit(int damage)
    {
        isHit = true;
        health -= damage;
        isHit = false;
        healthGauge.UpdateGauge(health, maxHP);
    }
    public void Heal(int healAmount)
    {
        if(health < maxHP)
        {
            health += healAmount;
            
            if(health > maxHP)
            {
                health = maxHP;
            }
        }
    }
}
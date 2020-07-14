using UnityEngine;
using System.Collections;
using UnityEngine.Events;

public class TowerStats : MonoBehaviour
{
    public int health;
    public bool isHit;
    public UnityEvent onGameOver;
    private int maxHP;


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
    }
}
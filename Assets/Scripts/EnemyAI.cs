using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    public string playerTag;
    public int damage;
    public float timer;
    public float attackCooldown;
    public EnemyStats enemyStats;
    public Transform towerPos;
    public float speed = 5;
    public bool isFrozen = false;

    public void Awake()
    {
        towerPos = GameObject.FindWithTag("Tower").transform;
    }

    internal void Freeze(float freezeAmount)
    {
        isFrozen = true;
        StartCoroutine(Unfreenze(freezeAmount));
        Debug.Log("congelou2");

    }

    private void OnTriggerStay(Collider col)
    {
        if(col.gameObject.tag == playerTag)
        {
            if(timer>= attackCooldown)
            {
                TowerStats stats = col.gameObject.GetComponent<TowerStats>();
                stats.Hit(damage);
                enemyStats.Hit(damage);
                timer = 0;
            }
        }
        timer += Time.deltaTime;
    }
    private void Update()
    {
        if (!isFrozen)
        {
            transform.parent.position = Vector3.MoveTowards(transform.parent.position, towerPos.position, Time.deltaTime * speed);
        }
    }
    private IEnumerator Unfreenze(float freezeAmount)
    {
        yield return new WaitForSeconds(freezeAmount);
        isFrozen = false;
    }
}

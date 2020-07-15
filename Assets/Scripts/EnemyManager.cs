using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Video;

public class EnemyManager : MonoBehaviour
{
    public int enemiesKilled;
    public int enemiesAmount;
    public float xMin;
    public float xMax;
    public float zMin;
    public float zMax;
    public GameObject enemy;
    public int maxEnemies;
    public GaugeUpdater enemyGauge;
    public TextMeshProUGUI enemyAmountText;
    public UnityEvent enemyOver;

    public void Start()
    {
        for (int i = 0; i < maxEnemies; i++)
        {
            Create();
        }
    }
    public void RegisterEnemiesKilled()
    {
        enemiesAmount--;
        UpdateUI();
        if (enemiesAmount == 0)
        {
            enemyOver.Invoke();
        }
    }
    private void RegisterNewEnemies()
    {
        enemiesAmount++;
        UpdateUI();
    }
    private void UpdateUI()
    {
        enemyGauge.UpdateGauge(enemiesAmount, maxEnemies);
        enemyAmountText.text = enemiesAmount.ToString() + "/" + maxEnemies.ToString(); 
    }
    private void Create()
    {
        float posX = Random.Range(xMin, xMax);
        float posZ = Random.Range(zMin, zMax);
        Vector3 pos = new Vector3(posX, 1.5f, posZ);
        Instantiate(enemy, pos, enemy.transform.rotation);
        RegisterNewEnemies();

    }
}

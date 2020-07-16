using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heal : MonoBehaviour
{
    public TowerStats towerStats;
    public int healAmount = 1;
    public float coolDown = 1;
    private bool canHeal = true;
    public void OnHeal()
    {
        if (canHeal)
        {
            towerStats.Heal(healAmount);
            canHeal = false;
            StartCoroutine(Cooldown());
        }
        
    }
    public IEnumerator Cooldown()
    {
        yield return new WaitForSeconds(coolDown);
        canHeal = true;
    }

}

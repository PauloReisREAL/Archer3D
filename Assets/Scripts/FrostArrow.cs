using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrostArrow : Arrow
{
    public float freezeAmount = 1;
    protected override void OnTriggerEnter(Collider other)
    {
        base.OnTriggerEnter(other);

        if (other.gameObject.tag == "Enemy")
        {
            other.GetComponent<EnemyAI>().Freeze(freezeAmount);
            Debug.Log("congelou1");
        }
    }
}

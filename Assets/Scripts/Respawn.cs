using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawn : MonoBehaviour
{
    public GameObject respawner;
    public float respawnCoolDown = 2;
    public Transform respawnReference;
    private Arrow currentArrow;
    private bool canShot = true;

    private void Start()
    {
        currentArrow = Instantiate(respawner, respawnReference.position, respawnReference.rotation, respawnReference).GetComponent<Arrow>();
    }

    public void Shot()
    {
        if (canShot)
        {
            currentArrow.OnShot();
            StartCoroutine(Cooldown(respawnCoolDown)); 
        }
    }

    IEnumerator Cooldown(float cooldown)
    {
        canShot = false;
        yield return new WaitForSeconds(cooldown);
        currentArrow = Instantiate(respawner, respawnReference.position, respawnReference.rotation, respawnReference).GetComponent<Arrow>();
        canShot = true;
    }
}

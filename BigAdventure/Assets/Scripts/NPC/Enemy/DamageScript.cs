using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageScript : MonoBehaviour
{
    float damageCount = 0.05f;
    float timer;
    PlayerContoller player;

    private void Update()
    {
        timer -= Time.deltaTime;
    }

    public void ApplyDamage()
    {
        if(timer <= 0)
        {
            StartCoroutine(player.ApplyDamage(damageCount));
            timer = 3.5f;
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        print("I trigger with the player");
        player = other.gameObject.GetComponent<PlayerContoller>();
        timer = 0;
        if(player != null && player.isDefending == false)
        {
            ApplyDamage();
        }else if (player != null && player.isDefending)
        {
            print("The player is defending cannot get damage");
        }
        else
        {
            print("Cannot find PlayerController");
        }
    }
}

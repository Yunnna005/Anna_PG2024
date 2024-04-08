using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageScript : MonoBehaviour
{
    float damageCount = 0.1f;
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
            player.ApplyDamage(damageCount);
            timer = 2;
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        print("I trigger with the player");
        player = other.gameObject.GetComponent<PlayerContoller>();
        timer = 0;
        ApplyDamage();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportShip2Controller : TeleportController
{
    //Teleport to the ship3
    private void Start()
    {
        spawnPosition = new Vector3(177.754f, 8.121f, 255.228f);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            TeleportPlayer(collision.gameObject.GetComponent<PlayerContoller>());
        }
    }
}

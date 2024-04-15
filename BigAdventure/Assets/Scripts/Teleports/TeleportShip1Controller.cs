using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportShip1Controller : TeleportController
{
    //Teleport to the ship2
    private void Start()
    {
        spawnPosition = new Vector3(123.82f, 8.237f, 143.73f);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            TeleportPlayer(collision.gameObject.GetComponent<PlayerContoller>());
        }
    }
}

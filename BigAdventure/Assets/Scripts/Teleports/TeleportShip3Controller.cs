using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportShip3Controller : TeleportController
{
    //Teleport to the beach
    private void Start()
    {
        spawnPosition = new Vector3(205.993f, 7.957f, 64.316f);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            TeleportPlayer(collision.gameObject.GetComponent<PlayerContoller>());
        }
    }
}

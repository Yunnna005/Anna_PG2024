using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportBeachController : TeleportController
{
    //Teleport to the village
    void Start()
    {
        spawnPosition = new Vector3(575.116f, 8.346f, 192.882f);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            TeleportPlayer(collision.gameObject.GetComponent<PlayerContoller>());
        }
    }
}

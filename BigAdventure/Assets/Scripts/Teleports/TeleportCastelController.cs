using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportCastelController : TeleportController
{
    //Teleport to the Town
    private void Start()
    {
        spawnPosition = new Vector3(603.836f, 1.301f, 265.043f);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            TeleportPlayer(collision.gameObject.GetComponent<PlayerContoller>());
        }
    }
}

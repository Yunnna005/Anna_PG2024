using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TeleportTownController : TeleportController
{
    //Teleportr to the Castel
    private void Start()
    {
        spawnPosition = new Vector3(382.625f, 27.393f, 273.364f);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            TeleportPlayer(collision.gameObject.GetComponent<PlayerContoller>());
        }
    }
}

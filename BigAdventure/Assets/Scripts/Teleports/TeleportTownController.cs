using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportTownController : MonoBehaviour
{
    //Teleportr to the Castel
    Vector3 spawnPosition = new Vector3(382.625f, 27.393f, 273.364f);
    private void OnCollisionEnter(Collision collision)
    {
        PlayerContoller player = collision.gameObject.GetComponent<PlayerContoller>();
        if (collision.gameObject.CompareTag("Player"))
        {
            player.transform.position = spawnPosition;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportShip2Controller : MonoBehaviour
{
    //Teleport to the ship3
    Vector3 spawnPosition = new Vector3(177.754f, 8.121f, 255.228f);
    private void OnCollisionEnter(Collision collision)
    {
        PlayerContoller player = collision.gameObject.GetComponent<PlayerContoller>();
        if (collision.gameObject.CompareTag("Player"))
        {
            player.transform.position = spawnPosition;
        }
    }
}

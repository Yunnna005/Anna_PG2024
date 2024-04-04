using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportShip1Controller : MonoBehaviour
{
    //Teleport to the ship2
    Vector3 spawnPosition = new Vector3(123.82f, 8.237f, 143.73f);
    private void OnCollisionEnter(Collision collision)
    {
        PlayerContoller player = collision.gameObject.GetComponent<PlayerContoller>();
        if (collision.gameObject.CompareTag("Player"))
        {
            player.transform.position = spawnPosition;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportVillageController : MonoBehaviour
{
    //Teleport to the beach
    Vector3 spawnPosition = new Vector3(205.993f, 7.957f, 64.316f);
    private void OnCollisionEnter(Collision collision)
    {
        PlayerContoller player = collision.gameObject.GetComponent<PlayerContoller>();
        if (collision.gameObject.CompareTag("Player"))
        {
            player.transform.position = spawnPosition;
        }
    }
}

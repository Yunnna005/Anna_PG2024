using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportBeachController : MonoBehaviour
{
    //Teleport to the village
    Vector3 spawnPosition = new Vector3(575.116f, 8.346f, 192.882f);
    private void OnCollisionEnter(Collision collision)
    {
        PlayerContoller player = collision.gameObject.GetComponent<PlayerContoller>();
        if (collision.gameObject.CompareTag("Player"))
        {
            player.transform.position = spawnPosition;
        }
    }
}

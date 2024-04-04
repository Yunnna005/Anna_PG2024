using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportCastelController : MonoBehaviour
{
    //Teleport to the Town
    Vector3 spawnPosition = new Vector3(603.836f, 1.301f, 265.043f);
    private void OnCollisionEnter(Collision collision)
    {
        PlayerContoller player = collision.gameObject.GetComponent<PlayerContoller>();
        if (collision.gameObject.CompareTag("Player"))
        {
            player.transform.position = spawnPosition;
        }
    }
}

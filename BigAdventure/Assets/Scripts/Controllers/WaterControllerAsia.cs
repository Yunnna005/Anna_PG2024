using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterControllerAsia : MonoBehaviour
{
    public PlayerContoller player;
    Vector3 spawnPosition = new Vector3(318.78f, 4.104f, -90.91f);

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            player.transform.position = spawnPosition;
        }
    }
}

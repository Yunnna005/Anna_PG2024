using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class waterController : MonoBehaviour
{
    public PlayerContoller player;
    Vector3 spawnPosition = new Vector3(191, 4.7f, 73.4f);


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            player.transform.position = spawnPosition;
        }  
    }
}

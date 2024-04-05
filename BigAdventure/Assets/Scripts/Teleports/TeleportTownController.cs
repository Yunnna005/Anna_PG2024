using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TeleportTownController : MonoBehaviour
{
    //Teleportr to the Castel
    Vector3 spawnPosition = new Vector3(382.625f, 27.393f, 273.364f);

    private void OnCollisionEnter(Collision collision)
    {
        PlayerContoller player = collision.gameObject.GetComponent<PlayerContoller>();

        player.transform.position = spawnPosition;  
    }
}

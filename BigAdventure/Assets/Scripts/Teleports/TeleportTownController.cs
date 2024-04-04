using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TeleportTownController : MonoBehaviour
{
    //Teleportr to the Castel
    Vector3 spawnPosition = new Vector3(382.625f, 27.393f, 273.364f);

    MeshCollider meshCollider;
    SphereCollider sphereCollider;

    private void Start()
    {
        meshCollider = GetComponent<MeshCollider>();
        sphereCollider = GetComponent<SphereCollider>();
    }
    private void OnCollisionEnter(Collision collision)
    {
        PlayerContoller player = collision.gameObject.GetComponent<PlayerContoller>();
        if (collision.gameObject.CompareTag("Player"))
        {
            if (player.playerLevel == 3)
            {
                sphereCollider.enabled = false;
                meshCollider.enabled = true;
                player.transform.position = spawnPosition;
            }
        }
    }
}

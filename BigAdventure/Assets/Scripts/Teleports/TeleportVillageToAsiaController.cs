using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class TeleportVillageToAsiaController : MonoBehaviour
{
    //Teleport to the Asia area
    Vector3 spawnPosition = new Vector3(371.48f, 3.039f, -115.36f);

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
            if(player.playerLevel == 5)
            {
                sphereCollider.enabled = false;
                meshCollider.enabled = true;
                player.transform.position = spawnPosition;
            }

        }
    }

}

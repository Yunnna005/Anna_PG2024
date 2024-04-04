using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class TeleportVillageToAsiaController : MonoBehaviour
{
    //Teleport to the Asia area
    Vector3 spawnPosition = new Vector3(371.48f, 3.039f, -115.36f);

    MeshCollider MeshCollider;
    SphereCollider SphereCollider;

    public Text text;
    private void Start()
    {
        MeshCollider = GetComponent<MeshCollider>();
        SphereCollider = GetComponent<SphereCollider>();
    }
    private void OnCollisionEnter(Collision collision)
    {
        PlayerContoller player = collision.gameObject.GetComponent<PlayerContoller>();
        if (collision.gameObject.CompareTag("Player"))
        {
            if(player.playerLevel == 5)
            {
                SphereCollider.enabled = false;
                MeshCollider.enabled = true;
                player.transform.position = spawnPosition;
            }
            else
            {
                text.enabled = true;
                text.text = "You didn't get level 5";
            }
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        text.enabled = false;
    }
}

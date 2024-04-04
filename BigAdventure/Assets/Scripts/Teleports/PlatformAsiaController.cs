using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformAsiaController : MonoBehaviour
{
    public Material skyboxNight;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            RenderSettings.skybox = skyboxNight;
        }
    }
}

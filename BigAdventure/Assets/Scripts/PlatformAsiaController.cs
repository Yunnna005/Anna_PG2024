using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformAsiaController : MonoBehaviour
{
    public Material skyboxNight;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            RenderSettings.skybox = skyboxNight;
        }
    }
}

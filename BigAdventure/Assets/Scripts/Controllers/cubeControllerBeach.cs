using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cubeControllerBeach : MonoBehaviour
{
    MeshRenderer MeshRenderer;
    // Start is called before the first frame update
    void Start()
    {
        MeshRenderer = GetComponent<MeshRenderer>();
        MeshRenderer.enabled = false;
    }

    private void OnCollisionEnter(Collision collision)
    {
        MeshRenderer.enabled = true;
    }
}

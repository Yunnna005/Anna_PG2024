using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextLevelController : MonoBehaviour
{
    public Canvas Canvas;
    public GameObject button;
    // Start is called before the first frame update
    void Start()
    {
        Canvas.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            Canvas.enabled = true;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        Canvas.enabled = false;
    }
}

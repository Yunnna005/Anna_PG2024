using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateItem : MonoBehaviour
{
    float xSpeed = 0;
    float ySpeed = 0;
    float zSpeed = 70;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(xSpeed*Time.deltaTime, ySpeed*Time.deltaTime, zSpeed*Time.deltaTime);
    }
}

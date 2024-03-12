using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseController : MonoBehaviour
{
    private float _mouseX;
    private float _mouseY;

    private float _horizontalSpeed = 2.0f;
    private float _verticalSpeed = 2.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        _mouseX = Input.GetAxis("Mouse X") * _horizontalSpeed;
        _mouseY = Input.GetAxis("Mouse Y") * _verticalSpeed;

        transform.Rotate(0, _mouseX, 0);

    }
}

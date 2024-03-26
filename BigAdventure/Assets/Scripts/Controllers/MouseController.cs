using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseController : MonoBehaviour
{
    private float _mouseX;
    private float _mouseY;

    private float _horizontalSpeed = 2.0f;
    private float _verticalSpeed = 3.0f;

    // Update is called once per frame
    void Update()
    {
        _mouseX = Input.GetAxis("Mouse X") * _horizontalSpeed;
        _mouseY = Input.GetAxis("Mouse Y") * _verticalSpeed;

        // Rotate the player horizontally based on mouse movement
        transform.Rotate(0, _mouseX, 0);

        // Rotate the cameras vertically based on mouse movement
        Camera.main.transform.Rotate(-_mouseY, 0, 0);
    }
}

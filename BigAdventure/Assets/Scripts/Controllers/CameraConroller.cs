using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraConroller : MonoBehaviour
{
    public GameObject camera_view1;
    public GameObject camera_view3;

    private Vector3 _orbit_camera_view1;
    private Vector3 _orbit_camera_view3;
    private float _turnSpeed = 1.0f;

    private float view1_Y = 1.053f;
    private float view1_Z = 0.217f;
    private float view3_Y = 2.3f;
    private float view3_Z = -2.8f;

    void Start()
    {
        camera_view1.SetActive(false);

        _orbit_camera_view1 = new Vector3(0, view1_Y, view1_Z);
        _orbit_camera_view3 = new Vector3(0, view3_Y, view3_Z);
    }

    void LateUpdate()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            SwitchToCamera1();
        }
        else if (Input.GetKeyDown(KeyCode.M))
        {
            SwitchToCamera3();
        }

        UpdateCameraPosition();
    }

    void SwitchToCamera1()
    {
        camera_view1.SetActive(true);
        camera_view3.SetActive(false);
    }

    void SwitchToCamera3()
    {
        camera_view1.SetActive(false);
        camera_view3.SetActive(true);
    }

    void UpdateCameraPosition()
    {
        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = Input.GetAxis("Mouse Y");

        // Adjust the orbit vectors based on horizontal mouse movement
        _orbit_camera_view3 = Quaternion.AngleAxis(mouseX * _turnSpeed, Vector3.up) * _orbit_camera_view3;
        _orbit_camera_view1 = Quaternion.AngleAxis(mouseX * _turnSpeed, Vector3.up) * _orbit_camera_view1;

        // Update the vertical rotation of the cameras
        camera_view1.transform.Rotate(Vector3.right, -mouseY * _turnSpeed);
        camera_view3.transform.Rotate(Vector3.right, -mouseY * _turnSpeed);

        // Update the camera positions relative to the player
        camera_view1.transform.position = transform.position + transform.TransformDirection(_orbit_camera_view1);
        camera_view3.transform.position = transform.position + transform.TransformDirection(_orbit_camera_view3);
    }
}

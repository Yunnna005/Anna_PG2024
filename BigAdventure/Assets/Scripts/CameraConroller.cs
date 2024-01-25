using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraConroller : MonoBehaviour
{
    //ChatGPT helped with logic. The code is mine.

    public GameObject player;
    public Camera camera_view1;
    public Camera camera_view3;

    private Vector3 _orbit_camera_view1;
    private Vector3 _orbit_camera_view3;
    private float _turnSpeed = 2.0f;

    private float view1_Y = 1.053f;
    private float view1_Z = 0.217f;
    private float view3_Y = 2.3f;
    private float view3_Z = -2.8f;
    // Start is called before the first frame update
    void Start()
    {
        camera_view1.enabled = false;

        _orbit_camera_view1 = new Vector3(player.transform.position.x, player.transform.position.y + view1_Y, player.transform.position.z + view1_Z);
        _orbit_camera_view3 = new Vector3(player.transform.position.x, player.transform.position.y + view3_Y, player.transform.position.z + view3_Z);
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            SwitchToCamera1();   
        }else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            SwitchToCamera3();
        }

        UpdateCameraPOsition();
    }

    void SwitchToCamera1()
    {
        camera_view1.enabled = true;
        camera_view3.enabled = false;
    }

    void SwitchToCamera3()
    {
        camera_view1.enabled = false;
        camera_view3.enabled = true;
    }

    void UpdateCameraPOsition()
    {
        _orbit_camera_view3 = Quaternion.AngleAxis(Input.GetAxis("Mouse X") * _turnSpeed, Vector3.up) * _orbit_camera_view3;
        _orbit_camera_view1 = Quaternion.AngleAxis(Input.GetAxis("Mouse X") * _turnSpeed, Vector3.up) * _orbit_camera_view1;

        camera_view1.transform.position = player.transform.position  + _orbit_camera_view1;

        camera_view3.transform.position = player.transform.position  + _orbit_camera_view3;

    }
}

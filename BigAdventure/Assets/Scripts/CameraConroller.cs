using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraConroller : MonoBehaviour
{
    //ChatGPT helped with logic. The code is mine.

    public GameObject player;
    public Camera camera_view1;
    public Camera camera_view3;

    //private Vector3 _offset_camera_view1 = new Vector3(0, 1.053f, 0.053f);
    //private Vector3 _offset_camera_view3 = new Vector3(-0.057f, 1.994f, -2.178f);

    private Vector3 _orbit_camera_view1;
    private Vector3 _orbit_camera_view3;
    private float _turnSpeed = 2.0f;
    // Start is called before the first frame update
    void Start()
    {
        camera_view1.enabled = false;

        _orbit_camera_view1 = new Vector3(player.transform.position.x, player.transform.position.y + 1.053f, player.transform.position.z + 0.2f);
        _orbit_camera_view3 = new Vector3(player.transform.position.x, player.transform.position.y + 3.0f, player.transform.position.z - 3.5f);
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
        //camera_view1.transform.LookAt(player.transform.position);
        camera_view3.transform.position = player.transform.position  + _orbit_camera_view3;
        camera_view3.transform.LookAt(player.transform.position);
    }
}

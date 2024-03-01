using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ballController : MonoBehaviour
{

    Rigidbody rb;

    private void Start()
    {
        rb = GetComponentInChildren<Rigidbody>();
    }
    //public Basketball_miniGame basketball_MiniGameScript;

    //void OnCollisionEnter(Collision collision)
    //{
    //    if (collision.gameObject.CompareTag("Ground"))
    //    {
    //        basketball_MiniGameScript.OnBallHitFloor();
    //    }
    //}

    internal void throwMe(Vector3 dir)
        {
        rb.AddForce(dir, ForceMode.Impulse);
        }

}

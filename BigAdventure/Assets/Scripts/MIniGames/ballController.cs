using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ballController : MonoBehaviour
{

    Rigidbody rb;
    float force = 10f;
    Basketball_miniGame basketball_MiniGameScript;

    private void Start()
    {
        rb = GetComponentInChildren<Rigidbody>();
        basketball_MiniGameScript = FindAnyObjectByType<Basketball_miniGame>();
    }

    public void throwMe(Vector3 dir)
        {
        if (rb == null)
            rb = GetComponentInChildren<Rigidbody>();
        
        
        rb.AddForce(dir*force, ForceMode.Impulse);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Basketball_basket"))
        {
            basketball_MiniGameScript.Reward(3);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("MiniGame"))
        {
            Destroy(gameObject);
        }
    }

}

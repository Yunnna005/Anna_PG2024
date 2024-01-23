using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerContoller : MonoBehaviour
{
    float leftRightMove;
    float backForwardMove;
    private float _speed = 5;
    private float _jumpForce = 300.0f;
    private bool _isOnGround = true;
    private float _gravityModifier = 1.2f;

    Rigidbody playerRigitbody;
    Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        playerRigitbody = GetComponent<Rigidbody>();

        Physics.gravity *= _gravityModifier;

        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        //Move Back or Forward
        backForwardMove = Input.GetAxis("Vertical");
        transform.Translate(Vector3.forward * _speed * Time.deltaTime * backForwardMove);
        animator.SetFloat("RunBackForward", backForwardMove);
        animator.SetBool("isRunningBackForward", backForwardMove > 0 || backForwardMove < 0);

        //Move left or right
        leftRightMove = Input.GetAxis("Horizontal");
        transform.Translate(Vector3.right * Time.deltaTime * _speed * leftRightMove);
        animator.SetFloat("runLeftRight", leftRightMove);
        animator.SetBool("isRunningLeftRight", leftRightMove > 0 || leftRightMove < 0);

        if (Input.GetKeyDown(KeyCode.Space) && _isOnGround)
        {
            playerRigitbody.AddForce(Vector3.up * _jumpForce, ForceMode.Impulse);
            _isOnGround = false;
            animator.SetBool("isJumping", true);
        }

        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            animator.SetBool("isAttacking", true);
        }
        else
        {
            animator.SetBool("isAttacking", false);
        }

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            _isOnGround = true;
            animator.SetBool("isJumping", false);
        }
    }

}

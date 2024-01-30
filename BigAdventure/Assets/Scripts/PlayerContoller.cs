using System.Collections;
using System.Collections.Generic;
using System.Net.Http.Headers;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

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

    public GameObject swordPrefab;

    private int _diamonds = 0;
    private int _health = 0;
    public Text diamondText;
    public Text healthText;
    public GameObject panelGameOver;

    float pickUpTimer;
    float PickUPAnimationTime = 1.50f;

    public Scrollbar healthBar;
    float playerHealth = 1.0f;
    // Start is called before the first frame update
    void Start()
    {
        playerRigitbody = GetComponent<Rigidbody>();

        Physics.gravity *= _gravityModifier;

        animator = GetComponent<Animator>();

        healthBar.size = playerHealth;

        panelGameOver.SetActive(false);
    }
    // Update is called once per frame
    void Update()
    {
        PlayerMovements();
        pickUpTimer -= Time.deltaTime;
        if (pickUpTimer <= 0)
        {
            animator.SetBool("isPickUp", false);
            //EnableObjectWithDelay();
        }

        if (playerHealth == 0)
        {
            gameObject.SetActive(false);
            print("GameOver");
            panelGameOver.SetActive(true);
        }
    }

    private void PlayerMovements()
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

        animator.SetBool("isAttacking", Input.GetKeyDown(KeyCode.Mouse0));

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            _isOnGround = true;
            animator.SetBool("isJumping", false);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Diamond"))
        {  
            startPickUP();
            Destroy(other.gameObject);
            _diamonds++;
            diamondText.text = "Diamonds: " + _diamonds;
            print("Diamonds: " + _diamonds);
        }

        if (other.gameObject.CompareTag("Heart"))
        {
            Destroy(other.gameObject);
            _health++;
            healthText.text = "Health: " + _health;
            startPickUP();
            if(playerHealth < 1.0f)
            {
                playerHealth += 0.05f;
                playerHealth = Mathf.Clamp01(playerHealth);
                healthBar.size = playerHealth;
            }
        }

        if (other.gameObject.CompareTag("Mushroom"))
        {
            Destroy(other.gameObject) ;
            playerHealth -= 0.1f;
            playerHealth = Mathf.Clamp01(playerHealth);
            healthBar.size = playerHealth;
        }
    }

    void startPickUP()
    {
        animator.SetBool("isPickUp", true);
        pickUpTimer = PickUPAnimationTime;
        //DisableObjectWithDelay();

    }

    IEnumerator DisableObjectWithDelay()
    {
        yield return new WaitForSeconds(0.01f); 
        swordPrefab.SetActive(false);
    }

    IEnumerator EnableObjectWithDelay()
    {
        yield return new WaitForSeconds(0.01f); 
        swordPrefab.SetActive(true);
    }

}

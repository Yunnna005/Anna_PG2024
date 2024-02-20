using System.Collections;
using System.Collections.Generic;
using System.Net.Http.Headers;
using System.Runtime.InteropServices.WindowsRuntime;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class PlayerContoller : MonoBehaviour, IPlayer
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
    public GameObject panelGameOver;

    float pickUpTimer;
    float PickUPAnimationTime = 1.50f;

    public Scrollbar healthBar;
    Text healthPercentage;
    float playerHealth = 1.0f;

    int playerExpreienceLevel = 0;
    public Scrollbar levelBar;
    int levelProgress = 0;
    int levelTarget = 100;
    Text levelPercentage;
    float levelBarSize = 0f;

    float currentMaxLevel;

    Inventory inventory;

    Item pickupItem;
    float PlayerHealth {  get { return playerHealth; }
        set
        {
            playerHealth = value;
            playerHealth = Mathf.Clamp01(playerHealth);
            healthBar.size = playerHealth;
            int percentage = (int) (playerHealth * 100);
            healthPercentage.text = percentage.ToString() + "/100";

        }

    }

    int PlayerProgress {  get { return levelProgress; } 
        set
        {
            levelProgress = value;
            if (levelProgress >= levelTarget)
            {
                playerExpreienceLevel++;
                levelProgress -= levelTarget;
                levelTarget = PlayerLevelSetandCheck(playerExpreienceLevel);
                
            }

            levelBarSize =  (float)levelProgress/levelTarget;
            levelBar.size = levelBarSize;

            levelPercentage.text = levelProgress + "/" + levelTarget;
        } 
    }



    // Start is called before the first frame update
    void Start()
    {
        playerRigitbody = GetComponent<Rigidbody>();

        Physics.gravity *= _gravityModifier;

        animator = GetComponent<Animator>();

        healthBar.size = playerHealth;
        healthPercentage = healthBar.GetComponentInChildren<Text>();

        levelBar.size = levelBarSize;
        levelPercentage = levelBar.GetComponentInChildren<Text>();
        levelPercentage.text = "0/100";

        panelGameOver.SetActive(false);

        inventory = GetComponent<Inventory>();
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
        ItemController itemController = other.GetComponent<ItemController>();
        pickupItem = itemController.Item;

        if (other.CompareTag("ItemToCollect"))
        {
            inventory.AddItem(pickupItem);
        }  


        if (pickupItem.damage)
        {
            print("I damaged the player");
            ApplyDamage(pickupItem.itemValue);
        }
        else if (pickupItem.heal)
        {
            print("I healled the player");
            ApplyHeal(pickupItem.itemValue);
        }else if (pickupItem.progress)
        {
            ApplyLevelProgress((int)pickupItem.itemValue);
        }

        Destroy(other.gameObject);
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


    public int PlayerLevelSetandCheck(int experienceLevel)
    {

        switch(experienceLevel)
        {
            case 0:
                return 100;
              
            case 1:
                return 250;
               
            case 2:
                return 400;
                
                case 3:
                return 600;
              
;
        default:
                return 1000;
        }
  
    }

    public void ApplyDamage(float value)
    {
        PlayerHealth -= value;
    }

    public void ApplyHeal(float value)
    {
        PlayerHealth += value;
    }

    public void ApplyLevelProgress(int value)
    {
        PlayerProgress += value;
    }
}

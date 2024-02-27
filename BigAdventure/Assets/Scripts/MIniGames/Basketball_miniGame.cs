using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Basketball_miniGame : MonoBehaviour
{
    public GameObject ball_prefab;
    public GameObject canvas;
    public Text canvas_text;
    public GameObject start_game_button;
    GameObject player;
    private bool isBallInPlay = false;

    // Start is called before the first frame update
    void Start()
    {
        canvas.SetActive(false);
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.R) && !isBallInPlay)
        {
            InstantiateNewBall();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            canvas.SetActive(true);
            canvas_text.text = "Basketball mini game.\r\n\rPress \"Start Game\" to start.";
        }
        else
        {
            canvas.SetActive(false);
        }
    }

    public void BasketballMiniGame()
    {
        print("Start mini basketball game");
        canvas_text.text = "Mini game started. \r\n\r\nTry to through the ball into the busket to get diamond. \r\n\r\nYou can get 3 diamonds.\r\n\r\nUse \"R\" to through the ball.";

        start_game_button.SetActive(false);
    }

    public void StartTheGame()
    {
        print("I am playing mini game. Im in Start the game method");
        canvas.SetActive(false);
    }

    private void InstantiateNewBall()
    {
        isBallInPlay = true;

        GameObject newBall = Instantiate(ball_prefab, player.transform.position, Quaternion.identity);
        newBall.transform.parent = player.transform;

        // Attach a script to the new ball to detect when it hits the floor
        //BallFallDetector ballFallDetector = newBall.AddComponent<BallFallDetector>();
        //ballFallDetector.ballInstantiationScript = this;
    }
    public void OnBallHitFloor()
    {
        isBallInPlay = false;
    }
}

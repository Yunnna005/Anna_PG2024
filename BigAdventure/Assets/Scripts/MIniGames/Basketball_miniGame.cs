using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Basketball_miniGame : MonoBehaviour, IPlayGame
{
    enum GameState { inActive, startingMessage, Playing, Rewarding, Ending }
    GameState isCurrently = GameState.inActive;
    public GameObject ball_prefab;
    public GameObject canvas;
    public Text canvas_text;
    public GameObject start_game_button;
    GameObject player;
    private bool isBallInGame = false;
    public float distance = 2.0f;
    GameObject newBall;
    PlayerContoller thePlayer;

    // Start is called before the first frame update
    void Start()
    {
        canvas.SetActive(false);
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        switch (isCurrently)
        {
            case GameState.inActive:

                break;

            case GameState.startingMessage:


                if (Input.GetKey(KeyCode.R))
                {
                    InstantiateNewBall();
                    isCurrently = GameState.Playing;
                    canvas.SetActive(false);

                }
                break;

            case GameState.Playing:
                
                
                break;
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
        canvas.SetActive(true);
    }

    public void InstantiateNewBall()
    {
        isBallInGame = true;

        Vector3 playerPosition = player.transform.position;
        Vector3 playerForward = player.transform.forward;

        Vector3 spawnPosition = playerPosition + playerForward;

        newBall = Instantiate(ball_prefab, spawnPosition, Quaternion.identity);
        thePlayer.YourBallIs(newBall.GetComponentInChildren<ballController>());
        //newBall.transform.parent = player.transform;
    }

    public void PlayingGame(PlayerContoller theNewPlayer)
    {
       if (isCurrently == GameState.inActive)
        {
            thePlayer = theNewPlayer;
            isCurrently = GameState.startingMessage;
            canvas.SetActive(true);
        }
    }

    public void EndGame()
    {
        isCurrently = GameState.inActive;
        thePlayer = null;
    }
}

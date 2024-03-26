using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Basketball_miniGame : MonoBehaviour, IPlayGame
{
    enum GameState { inActive, startingMessage, Playing, Rewarding, Ending, Finish }
    GameState isCurrently = GameState.inActive;
    public GameObject ball_prefab;
    public GameObject canvas;
    public Text canvas_text;
    public GameObject start_game_button;
    GameObject player;
    public float distance = 2.0f;
    GameObject newBall;
    PlayerContoller thePlayer;
    public GameObject diamondPrefab;
    int max_Reward = 0;
    float canvasTimer;
    float activeCanvasTime = 2.50f;

    // Start is called before the first frame update
    void Start()
    {
        canvas.SetActive(false);
        player = GameObject.FindGameObjectWithTag("Player");
        thePlayer = FindAnyObjectByType<PlayerContoller>();
    }

    // Update is called once per frame
    void Update()
    {
        switch (isCurrently)
        {
            case GameState.inActive:

                break;

            case GameState.startingMessage:


                if (Input.GetKeyDown(KeyCode.R))
                {
                  
                    isCurrently = GameState.Playing;
                    canvas.SetActive(false);

                }
                break;

            case GameState.Playing:

                if (Input.GetKeyDown(KeyCode.R))
                {
                    InstantiateNewBall();
                }
                break;

            case GameState.Ending:
                ActiveCanvas();
                break;
            case GameState.Finish:
                break;
        }

        canvasTimer -= Time.deltaTime;
    }


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
       
            canvas.SetActive(true);

            if(isCurrently == GameState.Finish)
            {
                canvas_text.text = "You have already played this game.";

            }
            else
            {
                thePlayer.PlayMode(true);
                canvas_text.text = "Basketball mini game.\r\n\rPress \"Start Game\" to start.";
            }

        }
        else
        {
            canvas.SetActive(false);

        }
    }

    private void OnCollisionExit(Collision collision) {
        canvas.SetActive(false);
    }

    public void BasketballMiniGame()
    {

        print("Start mini basketball game");
        canvas_text.text = "Mini game started. \r\n\r\nTry to through the ball into the busket to get diamond. \r\n\r\nYou can get 3 diamonds.\r\n\r\nUse \"R\" to through the ball.";
        thePlayer.DisArm();
        start_game_button.SetActive(false);

    }

    public void StartTheGame()
    {
        print("I am playing mini game. Im in Start the game method");
        canvas.SetActive(true);
    }

    public void InstantiateNewBall()
    {

        Vector3 playerPosition = player.transform.position;
        Vector3 playerForward = player.transform.forward;

        Vector3 spawnPosition = playerPosition + playerForward + Vector3.up;

        newBall = Instantiate(ball_prefab, spawnPosition, Quaternion.identity);
      
        thePlayer.YourBallIs(newBall.GetComponentInChildren<ballController>());

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
        canvas_text.text = "You got all rewards. The game is ended.";
        thePlayer.ActArm();
        isCurrently = GameState.Ending;
        canvasTimer = activeCanvasTime;
    }

    public void Reward(int maxReward)
    {
        int randomPosition = UnityEngine.Random.Range(-4, 7);
        Vector3 spawnPosition = this.transform.position + new Vector3((float)randomPosition, 0f, (float)randomPosition) + Vector3.up * 0.5f;

        Instantiate(diamondPrefab, spawnPosition, Quaternion.Euler(-90f, 0f, 0f));
        max_Reward++;

        if (max_Reward == maxReward)
        {
            EndGame();
            
        }
    }

    internal void ClearMessage()
    {
          canvas.SetActive(false);
    }

    public void ActiveCanvas()
    {
        if(canvasTimer<=0) 
        {
            canvas.SetActive(false);
            isCurrently = GameState.Finish;
        }
        else
        {
            canvas.SetActive(true);
        }
    }
}

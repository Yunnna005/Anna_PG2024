using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Basketball_miniGame : MonoBehaviour
{

    public GameObject ballPrefab;
    public GameObject canvas;
    public Text canvas_text;
    public Button start_game_button;


    public float timer = 10.0f;
    private bool timeStarted = false;
    private bool hasPlayerCollided = false;
    // Start is called before the first frame update
    void Start()
    {
        canvas.SetActive(false);
        start_game_button.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (timeStarted) {
            timer -= Time.deltaTime;
            setCanvasActive();
        }

        if (hasPlayerCollided)
        {
            BasketballMiniGame();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            print("Start mini basketball game");
            timeStarted = true;
            hasPlayerCollided = true;
        }
        else
        {
            canvas.SetActive(false);
        }
    }

    private void BasketballMiniGame()
    {
        
    }

    private void setCanvasActive()
    {
        if (timer <= 0.0f)
        {
            canvas.SetActive(false);
            timer = 0.0f;
        }
        else
        {
            canvas.SetActive(true);
            canvas_text.text = "Mini game started. \r\n\r\nTry to through the ball into the busket to get diamond. \r\n\r\nYou can get 3 diamonds.\r\n\r\nUse \"R\" to through the ball.";
        }
    }
}

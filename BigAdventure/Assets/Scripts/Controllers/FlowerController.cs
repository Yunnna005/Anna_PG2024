using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.UI;

public class FlowerController : MonoBehaviour
{
    float timerTime;

    private void Update()
    {
        if (timerTime > 0) 
        {
            timerTime -= Time.deltaTime;
            if (timerTime <= 0) 
            {
                GameController gameController = FindObjectOfType<GameController>(); 
                if (gameController != null)
                {
                    gameController.BackToStartScene();
                }
            }
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            print("i collide with player");
            Canvas[] Canvases = FindObjectsOfType<Canvas>();
            foreach (Canvas c in Canvases)
            {
                if (c != null && c.name == "CanvasGeneral_Text")
                {
                    print(c.name );
                    c.enabled = true;
                    Text canvasText = c.GetComponentInChildren<Text>();
                    if (canvasText != null)
                    {
                        canvasText.enabled = true;
                        canvasText.text = "Game Over.\n\nYou have completed all the missions.\n\nComming back to the main manu.";
                        timerTime = 5;
                    }
                }
            }
        }
    }
}

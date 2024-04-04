using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HarukoController : MonoBehaviour
{
    enum GameState { Start, Talking, End }
    GameState isCurrent;
    public Text dialogueText;
    private int currentIndex = 0;
    private float lastKeyPressTime = 0f;
    private float keyPressCooldown = 3f; // Cooldown time in seconds

    string[] NPCText = new string[] {
        "Hello Traveler!",
        "Your mission is to find the missing flower",
        "Help us collect different items and save our world from enemies",
        "Use teleports to move between places",
        "Raise your level by completing tasks and uncoking more places",
        "Good luck!"
    };

    private void Start()
    {
        dialogueText.enabled = false;
    }

    void Update()
    {
        // Update the timer
        lastKeyPressTime += Time.deltaTime;

        switch (isCurrent)
        {
            case GameState.Start:
                dialogueText.text = "Press T to start and to continue conversation";
                if (Input.GetKeyDown(KeyCode.T))
                {
                    isCurrent = GameState.Talking;
                    StartConversation(NPCText);
                }
                break;
            case GameState.Talking:
                if (Input.GetKeyDown(KeyCode.T) && CanPressKey())
                {
                    if (currentIndex < NPCText.Length - 1)
                    {
                        currentIndex++;
                        dialogueText.text = NPCText[currentIndex];
                    }
                    else
                    {
                        isCurrent = GameState.End;
                    }
                }
                break;
            case GameState.End:
                break;
        }
    }

    // Check if the key can be pressed (based on cooldown)
    bool CanPressKey()
    {
        return lastKeyPressTime >= keyPressCooldown;
    }

    private void StartConversation(string[] nPCText)
    {
        dialogueText.text = nPCText[currentIndex];
        lastKeyPressTime = 0f;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isCurrent = GameState.Start;
            dialogueText.enabled = true;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        dialogueText.enabled = false;
    }
}

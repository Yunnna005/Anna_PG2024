using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC_Controller : MonoBehaviour
{
    enum GameState { Start, Talking, End }
    GameState isCurrent;

    public string[] dialogLines;
    private int currentLineIndex = 0;
    private DialogueManager dialogueManager;

    private float lastKeyPressTime = 0f;
    private float keyPressCooldown = 1.5f;
    private bool isStarted = false;

    void Start()
    {
        dialogueManager = FindObjectOfType<DialogueManager>();
    }

    public void StartDialogue()
    {
        isStarted = true;
        isCurrent = GameState.Start;
    }

    private void Update()
    {
        if (isStarted)
        {
            lastKeyPressTime += Time.deltaTime;

            switch (isCurrent)
            {
                case GameState.Start:
                    dialogueManager.StartDialogue("Press T to start and to continue conversation");
                    if (Input.GetKeyDown(KeyCode.T))
                    {
                        isCurrent = GameState.Talking;
                        StartConversation(dialogLines);
                    }
                    break;
                case GameState.Talking:
                    if (Input.GetKeyDown(KeyCode.T) && CanPressKey())
                    {
                        if (currentLineIndex < dialogLines.Length - 1)
                        {
                            currentLineIndex++;
                            dialogueManager.StartDialogue(dialogLines[currentLineIndex]);
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
    }

    bool CanPressKey()
    {
        return lastKeyPressTime >= keyPressCooldown;
    }

    private void StartConversation(string[] nPCText)
    {
        dialogueManager.StartDialogue(nPCText[currentLineIndex]);
        lastKeyPressTime = 0f;
    }
    private void OnCollisionExit(Collision collision)
    {
        dialogueManager.HideText();
    }
    private void OnCollisionEnter(Collision collision)
    {
        dialogueManager.ShowText();
    }

}

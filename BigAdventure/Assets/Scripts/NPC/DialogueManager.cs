using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    public Text dialogueText;

    public void StartDialogue(string dialogueLine)
    {
        dialogueText.text = dialogueLine;
    }

    public void HideText()
    {
        dialogueText.enabled = false;
    }   
    public void ShowText()
    {
        dialogueText.enabled = true ;
    }
}

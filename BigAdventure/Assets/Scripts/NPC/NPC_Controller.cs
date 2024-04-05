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
    bool isSellingDiamonds = false;

    SellController sellController;
    string sellingItemName;
    int sellingItemQty;

    PlayerContoller player;

    void Start()
    {
        dialogueManager = FindObjectOfType<DialogueManager>();
    }

    public void StartDialogue()
    {
        isStarted = true;
        currentLineIndex = 0;
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
                    isSellingDiamonds = true;
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
        isStarted = false;
        dialogueManager.HideText();
    }
    private void OnCollisionEnter(Collision collision)
    {
        player = collision.gameObject.GetComponent<PlayerContoller>();
        dialogueManager.ShowText();
    }

    public void onPointerClickEventTrigger()
    {
        if(player != null)
        {
            print("I want to sell");
            if (isSellingDiamonds){
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

                RaycastHit hit;
                if (Physics.Raycast(ray, out hit))
                {
                    if (hit.collider)
                    {
                        sellController = hit.collider.gameObject.GetComponent<SellController>();
                        if (sellController.itemToSell != null)
                        {
                            sellingItemName = sellController.itemToSell.itemName;
                            sellingItemQty = sellController.itemToSell.qtyToSell;
                        }
                        else
                        {
                            print("The Selling Item script was not assigned");
                        }

                    }
                }

                print("Ready to sell");
                if(player.inventory.CkeckItemQty(sellingItemName, sellingItemQty))
                {
                    player.ApplyLevelProgress(sellingItemQty * sellingItemQty);
                    player.inventory.RemoveItem(player.inventory.FindItem(sellingItemName), sellingItemQty);
                    dialogueManager.StartDialogue("You sold " + sellingItemQty + " " + sellingItemName + "s");
                    print("I have "+sellingItemQty+" "+sellingItemName);
                }
                else
                {
                    dialogueManager.StartDialogue("You don't have " + sellingItemQty + " " + sellingItemName +"s");
                }
            }
            else
            {
                dialogueManager.StartDialogue("Please start conversation");
            }
        }
    }
}

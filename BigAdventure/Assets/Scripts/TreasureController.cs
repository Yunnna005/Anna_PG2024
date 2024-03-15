using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class TreasureController : MonoBehaviour
{
    public Text text;
    // Start is called before the first frame update
    void Start()
    {
        text.enabled = false;
        text.text = "Press F to get the tresure";
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TreasureOpen(PlayerContoller player)
    {
        text.enabled = true;
        player.CollectTreasure(true);
    }

    public void GetReward()
    {
        text.enabled = false;
        Destroy(gameObject);
        print("I got reward");
    }
}

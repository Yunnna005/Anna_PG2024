using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class TreasureController : MonoBehaviour
{
    public Text text;
    public GameObject diamondPrefab;

    Vector3 spawnPosition;
    float position_y_diamond = 0.6f;
    int maxReward = 0;
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

        while (maxReward != 3)
        {
            int randomNum = UnityEngine.Random.Range(-1, 3);
            spawnPosition = new Vector3(transform.position.x+ randomNum, position_y_diamond, transform.position.z+randomNum);
            Instantiate(diamondPrefab, spawnPosition, Quaternion.Euler(-90f, 0f, 0f));
            maxReward++;
        }
        print("I got reward");
    }

    public void CantBeOpen()
    {
        text.enabled = true;
        text.text = "You do not have key";
    }
    public void CleareMessage(PlayerContoller player)
    {
        text.enabled = false;
        player.CollectTreasure(false);
    }
}

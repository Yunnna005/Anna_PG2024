using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.VersionControl;
using UnityEngine;
using UnityEngine.UI;

public class TreasureController : MonoBehaviour
{
    public Text text;
    public GameObject diamondPrefab;
    public GameObject particle;
    ParticleSystem effect;

    Vector3 spawnPosition;
    float position_y_diamond = 1.6f;
    int maxReward = 0;
    float radius = 5;
    float distance;

    public float targetTime = 1.0f;


    // Start is called before the first frame update
    void Start()
    {
        text.enabled = false;

        effect = particle.GetComponent<ParticleSystem>();
        effect.Stop();
    }

    private void Update()
    {


    }

    public void TreasureOpen(PlayerContoller player)
    {
        text.enabled = true;
        player.CollectTreasure(true);
    }

    public void DestroyTreasureChest()
    {
        print("DTC");
        text.enabled = false;
        effect.Play();
        GetReward();
    }

    public void GetReward()
    {
        while (maxReward != 3)
        {
            float randomNum = UnityEngine.Random.Range(-.5f, 0.5f);
            spawnPosition = new Vector3(transform.position.x + randomNum, position_y_diamond, transform.position.z + randomNum);
            Instantiate(diamondPrefab, spawnPosition, Quaternion.Euler(-90f, 0f, 0f));
            maxReward++;
        }
        if (maxReward == 3)
        {
            Destroy(gameObject, 0.5f);
        }
        print("I got reward");
    }

    public void CantBeOpen()
    {
        text.enabled = true;
        text.text = "You do not have key";
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            text.text = "Press F to get the tresure";
            distance = Vector3.Distance(transform.position, collision.transform.position);
            if (distance <= radius)
            {
                text.enabled = true;
            }
            else
            {
                text.enabled = false;
            }
        }

    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            text.enabled = false;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyController : MonoBehaviour
{
    public GameObject Canvas;
    Text text;
    float timer;
    int enemyHealth;
    int damageCount = 10;
    public GameObject bonePrefab;
    int maxReward = 3;
    int rewardCount = 0;
    float position_y_bone = 0.3f;
    Vector3 spawnPosition;
    bool isFighting = false;
    // Start is called before the first frame update
    void Start()
    {
        text = Canvas.GetComponentInChildren<Text>();
        Canvas.SetActive(false);
        enemyHealth = 100;
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        if (enemyHealth <= 0)
        {
            GetReward();
        }

        if (text != null)
            text.text = "Enemy Health: " + enemyHealth + "/100";
    }

    private void OnTriggerEnter(Collider other)
    {
        Canvas.SetActive(true);
        if (other.gameObject.CompareTag("Weapon") && isFighting)
        {

            timer = 0;
            ApplyDamage();
        }
        else
        {
            if (text != null)
                Canvas.SetActive(false);
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        if (text != null)
            Canvas.SetActive(false);
    }

    public void StartFighting(bool isStarted)
    {
        isFighting = isStarted;
    }

    private void ApplyDamage()
    {
        if (timer<=0)
        {
            enemyHealth -= damageCount;
            timer = 4;
        }
    }

    private void GetReward()
    {
        while (rewardCount != maxReward)
        {
            float randomNum = UnityEngine.Random.Range(-.5f, 0.5f);
            spawnPosition = new Vector3(transform.position.x + randomNum, transform.position.y+position_y_bone, transform.position.z + randomNum);
            Instantiate(bonePrefab, spawnPosition, Quaternion.Euler(-90f, 0f, 0f));
            rewardCount++;
        }
        if (rewardCount >= 3)
        {
            if (text != null)
                Canvas.SetActive(false);
            Destroy(gameObject, 0.5f);
        }
    }
}

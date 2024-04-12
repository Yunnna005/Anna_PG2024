using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public Material skyboxDay;
    public GameObject player;

    public GameObject diamondPrehab;
    public GameObject treasureChestPrehab;
    public GameObject keyPrehab;
    public GameObject mushroomPrehab;
    public GameObject fishPrehab;
    public GameObject heartPrehab;
    public GameObject enemyPrehab;
    public GameObject applePrehab;
    public GameObject rockPrehab;


    PlayerContoller playerController;
    Transform[] SpawnPoints;

    Vector3 startPosition = new Vector3(603.87f, 1.29f, 264.9f);

    List<Transform> diamondPoints123 = new List<Transform>();
    List<Transform> diamondPoints4 = new List<Transform>(); 
    List<Transform> treasureChestPoints = new List<Transform>(); 
    List<Transform> treasureChestPoints4 = new List<Transform>(); 
    List<Transform> keyPoints = new List<Transform>(); 
    List<Transform> keyPoints4 = new List<Transform>(); 
    List<Transform> mushroomPoints = new List<Transform>(); 
    List<Transform> fishPoints = new List<Transform>(); 
    List<Transform> heartPoints = new List<Transform>(); 
    List<Transform> heartPoints4 = new List<Transform>(); 
    List<Transform> enemyPoints = new List<Transform>(); 
    List<Transform> enemyPoints4 = new List<Transform>();
    List<Transform> applePoints = new List<Transform>();
    List<Transform> rockPoints = new List<Transform>();

    private void Start()
    {
        player.transform.position = startPosition;
        playerController = player.GetComponent<PlayerContoller>();
        RenderSettings.skybox = skyboxDay;
        FindAllPoints();
        InstantiateKeyPoints();
    }
    private void Update()
    {
        if(playerController.playerLevel == 3)
        {
            InstantiateKeyPoints();
        }
    }
    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); 
    }

    public void BackToStartScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);  
    }

    public void FindAllPoints()
    {
        int i = 0;
        SpawnPoints = GetComponentsInChildren<Transform>();

        while (i!= SpawnPoints.Length)
        {
            Transform currentObject = SpawnPoints[i];

            // Check if the object's name matches the desired name pattern
            switch (currentObject.name)
            {
                case "DiamondPoints0_1_2":
                    diamondPoints123.Add(currentObject);
                    break;
                case "DiamondPoints4":
                    diamondPoints4.Add(currentObject);
                    break;
                case "TreasureChestPoints":
                    treasureChestPoints.Add(currentObject);
                    break;
                case "TreasureChestPoints4":
                    treasureChestPoints4.Add(currentObject);
                    break;
                case "KeysPoints":
                    keyPoints.Add(currentObject);
                    break;
                case "KeysPoints4":
                    keyPoints4.Add(currentObject);
                    break;
                case "MushroomPoints":
                    mushroomPoints.Add(currentObject);
                    break;
                case "FishPoints":
                    fishPoints.Add(currentObject);
                    break;
                case "HeartPoints":
                    heartPoints.Add(currentObject);
                    break;
                case "HeartPoints4":
                    heartPoints4.Add(currentObject);
                    break;
                case "EnemyPoints":
                    enemyPoints.Add(currentObject);
                    break;
                case "EnemyPoints4":
                    enemyPoints4.Add(currentObject);
                    break;
                case "applePoints":
                    applePoints.Add(currentObject);
                    break;
                case "rockPoints":
                    rockPoints.Add(currentObject);
                    break;
            }

            i++;
        }

        print("DiamondPoints0_1_2    "+ diamondPoints123.Count);
        print("DiamondPoints4    " + diamondPoints4.Count);
        print("treasureChestPoints   " + treasureChestPoints.Count);
        print("treasureChestPoints4   " + treasureChestPoints4.Count);
        print("KeyPoints   " + keyPoints.Count);
        print("KeyPoints4   " + keyPoints4.Count);
        print("MushroomPoints   " + mushroomPoints.Count);
        print("FishPoints   " + fishPoints.Count);
        print("HeartPoints   " +    heartPoints.Count);
        print("HeartPoints4   " + heartPoints4.Count);
        print("EnemyPoints   " + enemyPoints.Count);
        print("EnemyPoints4   " + enemyPoints4.Count);
        print("ApplePoints   " + applePoints.Count);
        print("RockPoints   " + rockPoints.Count);
    }

    public void InstantiateKeyPoints()
    {
        if(playerController.playerLevel < 3)
        {
            foreach (Transform keyPoint in diamondPoints123)
            {
                Instantiate(diamondPrehab, keyPoint.position, Quaternion.Euler(-90f, 0f, 0f));
            }
            foreach (Transform keyPoint in treasureChestPoints)
            {
                Instantiate(treasureChestPrehab, keyPoint.position, keyPoint.rotation);
            }
            foreach (Transform keyPoint in keyPoints)
            {
                Instantiate(keyPrehab, keyPoint.position, keyPoint.rotation);
            }
            foreach (Transform keyPoint in mushroomPoints)
            {
                Instantiate(mushroomPrehab, keyPoint.position, keyPoint.rotation);
            }
            foreach (Transform keyPoint in heartPoints)
            {
                Instantiate(heartPrehab, keyPoint.position, Quaternion.Euler(-90f, 0f, 0f));
            }
            foreach (Transform keyPoint in enemyPoints)
            {
                Instantiate(enemyPrehab, keyPoint.position, keyPoint.rotation);
            }            
            foreach (Transform keyPoint in applePoints)
            {
                Instantiate(applePrehab, keyPoint.position, keyPoint.rotation);
            }            
            foreach (Transform keyPoint in rockPoints)
            {
                Instantiate(rockPrehab, keyPoint.position, keyPoint.rotation);
            }
        }
        if (playerController.playerLevel == 3)
        {
            foreach (Transform keyPoint in diamondPoints4)
            {
                Instantiate(diamondPrehab, keyPoint.position, Quaternion.Euler(-90f, 0f, 0f));
            }
            foreach (Transform keyPoint in treasureChestPoints4)
            {
                Instantiate(treasureChestPrehab, keyPoint.position, keyPoint.rotation);
            }
            foreach (Transform keyPoint in keyPoints4)
            {
                Instantiate(keyPrehab, keyPoint.position, keyPoint.rotation);
            }
            foreach (Transform keyPoint in fishPoints)
            {
                Instantiate(fishPrehab, keyPoint.position, keyPoint.rotation);
            }
            foreach (Transform keyPoint in heartPoints4)
            {
                Instantiate(heartPrehab, keyPoint.position, Quaternion.Euler(-90f, 0f, 0f));
            }
            foreach (Transform keyPoint in enemyPoints4)
            {
                Instantiate(enemyPrehab, keyPoint.position, keyPoint.rotation);
            }
        }

    }
}

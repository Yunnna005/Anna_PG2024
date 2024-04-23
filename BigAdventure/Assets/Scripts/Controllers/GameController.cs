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

    Vector3 startPosition = new Vector3(603.87f, 1.29f, 264.9f);

    Dictionary<string, List<Transform>> spawnPoints = new Dictionary<string, List<Transform>>();

    bool isInstantiated = false;

    int targetPlayerLevel = 4;

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
        if(playerController.playerLevel >= targetPlayerLevel)
        {
            if (isInstantiated == false)
            {
                InstantiateKeyPoints();
            }
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

    private void FindAllPoints()
    {
        Transform[] allTransforms = GetComponentsInChildren<Transform>();

        foreach (Transform point in allTransforms)
        {
            switch (point.name)
            {
                case "DiamondPoints0_1_2":
                case "DiamondPoints4":
                case "TreasureChestPoints":
                case "TreasureChestPoints4":
                case "KeysPoints":
                case "KeysPoints4":
                case "MushroomPoints":
                case "FishPoints":
                case "HeartPoints":
                case "HeartPoints4":
                case "EnemyPoints":
                case "EnemyPoints4":
                case "applePoints":
                case "rockPoints":
                
                    
               if (!spawnPoints.ContainsKey(point.name))
               {
                  spawnPoints.Add(point.name, new List<Transform>());
               }
               spawnPoints[point.name].Add(point);
               break;
            }
        }

        foreach (var entry in spawnPoints)
        {
            Debug.Log(entry.Key + " Count: " + entry.Value.Count);
        }
    }

    private void InstantiateObjectsFromPoints(List<Transform> points, GameObject prefab)
    {
        foreach (Transform spawnPoint in points)
        {
            if(spawnPoint.name == "DiamondPoints0_1_2" || spawnPoint.name == "DiamondPoints4" || spawnPoint.name == "HeartPoints"|| spawnPoint.name == "HeartPoints4")
            {
                Instantiate(prefab, spawnPoint.position, Quaternion.Euler(-90, 0, 0));
            }
            else
            {
                Instantiate(prefab, spawnPoint.position, spawnPoint.rotation);
            }
        }
    }

    private void InstantiateKeyPoints()
    {
        if (playerController.playerLevel < targetPlayerLevel)
        {
            InstantiateObjectsFromPoints(spawnPoints["DiamondPoints0_1_2"], diamondPrehab);
            InstantiateObjectsFromPoints(spawnPoints["TreasureChestPoints"], treasureChestPrehab);
            InstantiateObjectsFromPoints(spawnPoints["KeysPoints"], keyPrehab);
            InstantiateObjectsFromPoints(spawnPoints["MushroomPoints"], mushroomPrehab);
            InstantiateObjectsFromPoints(spawnPoints["HeartPoints"], heartPrehab);
            InstantiateObjectsFromPoints(spawnPoints["EnemyPoints"], enemyPrehab);
            InstantiateObjectsFromPoints(spawnPoints["applePoints"], applePrehab);
            InstantiateObjectsFromPoints(spawnPoints["rockPoints"], rockPrehab);
        }

       if (playerController.playerLevel >= targetPlayerLevel)
        {
            InstantiateObjectsFromPoints(spawnPoints["DiamondPoints4"], diamondPrehab);
            InstantiateObjectsFromPoints(spawnPoints["TreasureChestPoints4"], treasureChestPrehab);
            InstantiateObjectsFromPoints(spawnPoints["KeysPoints4"], keyPrehab);
            InstantiateObjectsFromPoints(spawnPoints["FishPoints"], fishPrehab);
            InstantiateObjectsFromPoints(spawnPoints["HeartPoints4"], heartPrehab);
            InstantiateObjectsFromPoints(spawnPoints["EnemyPoints4"], enemyPrehab);

            isInstantiated = true;
        }
    }
}

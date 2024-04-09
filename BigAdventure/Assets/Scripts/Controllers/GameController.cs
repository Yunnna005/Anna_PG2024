using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public Material skyboxDay;
    public GameObject player;

    Vector3 startPosition = new Vector3(603.87f, 1.29f, 264.9f);
    private void Start()
    {
        player.transform.position = startPosition;
        RenderSettings.skybox = skyboxDay;
    }
    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); //need to be fix to load start scene
        print("The button is working");
    }
}

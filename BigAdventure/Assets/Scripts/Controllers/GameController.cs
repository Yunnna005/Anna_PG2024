using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public Material skyboxDay;

    private void Start()
    {
        RenderSettings.skybox = skyboxDay;
    }
    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); //need to be fix to load start scene
        print("The button is working");
    }
}

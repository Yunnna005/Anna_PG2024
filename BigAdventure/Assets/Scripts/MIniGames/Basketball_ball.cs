using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Basketball_ball : MonoBehaviour
{
    public GameObject canvas;
    public Button start_game_button;
    // Start is called before the first frame update

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            canvas.SetActive(true);
            start_game_button.enabled = true;
        }
    }
}

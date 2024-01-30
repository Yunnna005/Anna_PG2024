using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemCollector : MonoBehaviour
{
    private int _diamonds = 0;
    private int _health = 0;
    public Text diamondText;
    public Text healthText;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Diamond"))
        {
            Destroy(other.gameObject);
            _diamonds++;
            diamondText.text = "Diamonds: " + _diamonds;
            print("Diamonds: "+_diamonds);
        }

        if (other.gameObject.CompareTag("Heart"))
        {
            Destroy(other.gameObject);
            _health++;
            healthText.text = "Health: " + _health;
        }
    }
}

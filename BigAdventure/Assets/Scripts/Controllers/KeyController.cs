using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyController : MonoBehaviour
{
    float movementRange = 0.2f; // Range of movement
    float movementSpeed = 0.2f; // Speed of movement

    private Vector3 initialPosition;
    private bool movingUp = true;

    void Start()
    {
        initialPosition = transform.position;
    }

    void Update()
    {
        // Calculate new position based on movement speed and direction
        float newYPos = transform.position.y + (movingUp ? 1 : -1) * movementSpeed * Time.deltaTime;

        // Check if the item has reached the upper or lower limit of movement range
        if (newYPos >= initialPosition.y + movementRange)
        {
            newYPos = initialPosition.y + movementRange;
            movingUp = false;
        }
        else if (newYPos <= initialPosition.y - movementRange)
        {
            newYPos = initialPosition.y - movementRange;
            movingUp = true;
        }

        // Set the new position of the item
        transform.position = new Vector3(transform.position.x, newYPos, transform.position.z);
    }
}

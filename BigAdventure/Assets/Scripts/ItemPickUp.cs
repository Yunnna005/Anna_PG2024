using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickUp : MonoBehaviour
{
    public Item Item;

    void Pickup()
    {
        Inventory.Instance.AddItem(Item);
        Destroy(gameObject);
    }

}

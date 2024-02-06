using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.FullSerializer;
using UnityEngine;

public class Inventory : MonoBehaviour
{

    public static Inventory Instance;
    int NumberOfSlots = 6;
    List<Item> inventorySlots;


    private void Awake()
    {
        Instance = this;
    }
    public Inventory(int numberOfSlots)
    {
        NumberOfSlots = numberOfSlots;
        inventorySlots = new List<Item>();

    }


    public bool AddItem(Item item)
    {
        if (inventorySlots.Count < NumberOfSlots) {
            inventorySlots.Add(item);
            return true;
           
        }
        else { return false; }

    }

    public void RemoveItem(Item item) 
    {
        inventorySlots.Remove(item);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory 
{
    int NumberOfSlots;
    List<Item> inventorySlots;

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
}

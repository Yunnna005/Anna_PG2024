using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using Unity.VisualScripting.FullSerializer;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    Dictionary<Item, int> inventorySlots;

    public Transform ItemContent; 
    public GameObject InventoryItem;

    public GameObject content;

    void Start()
    {
        inventorySlots = new Dictionary<Item, int>();
    }
    public void AddItem(Item item){

        if (inventorySlots.ContainsKey(item)){
            inventorySlots[item]++;
            ListItems();
        }
        else
        {
            print("The item in AddItem method");
            inventorySlots.Add(item, 1);
            ListItems();
        }
        foreach (var kvp in inventorySlots) // to check if item in the inventorySlot
        {
            Item item1 = kvp.Key;
            int quantity = kvp.Value;

            Debug.Log($"Item: {item1.name}, Quantity: {quantity}");
        } 
    }

    public void RemoveItem(Item item) 
    {
        inventorySlots.Remove(item);
    }

    public void ListItems()
    {
        foreach (var (item, quantity) in inventorySlots) 
        {
            GameObject slot = HasDuplicate(item);

            if (slot != null)
            {
                // Update existing slot
                var itemQty = slot.transform.Find("ItemQty").GetComponent<Text>();
                itemQty.text = quantity.ToString();
            }
            else
            {
                GameObject itemSlot = Instantiate(InventoryItem, ItemContent);
                var itemName = itemSlot.transform.Find("ItemName").GetComponent<Text>();
                var itemIcon = itemSlot.transform.Find("ItemIcon").GetComponent<Image>();
                var itemQty = itemSlot.transform.Find("ItemQty").GetComponent<Text>();

                print(quantity);
                itemName.text = item.itemName;
                itemIcon.sprite = item.icon;
                itemQty.text = quantity.ToString();
            }

        }
    }

    private GameObject HasDuplicate(Item target)
    {
        foreach (Transform child in content.transform)
        {
            var itemName = child.transform.Find("ItemName").GetComponent<Text>();

            if (itemName.text == target.itemName)
            {
                
                return child.gameObject;
            }
        }

        return null;
    }
}

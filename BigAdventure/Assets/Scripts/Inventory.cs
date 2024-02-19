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

    void Start()
    {
        inventorySlots = new Dictionary<Item, int>();
    }
    public void AddItem(Item item){

        if (inventorySlots.ContainsKey(item)){
            inventorySlots[item]++;
        }
        else
        {
            print("The item in AddItem method");
            inventorySlots.Add(item, 1);
            ListItems();
        }
        foreach (var kvp in inventorySlots)
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
            GameObject GObject = Instantiate(InventoryItem, ItemContent);
            var itemName = GObject.transform.Find("ItemName").GetComponent<Text>();
            var itemIcon = GObject.transform.Find("ItemIcon").GetComponent<Image>(); 
            var itemQty = GObject.transform.Find("ItemQty").GetComponent<Text>();

            itemName.text = item.itemName;
            itemIcon.sprite = item.icon;
            itemQty.text = quantity.ToString();
        }
    }
}

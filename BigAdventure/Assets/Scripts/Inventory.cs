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
            if (IsDupa(item.itemName) != null)
            {
                GameObject slot = IsDupa(item.itemName);

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

    private GameObject IsDupa(string target)
    {
        if (content == null) return null;
        GameObject[] allContent = content.GetComponents<GameObject>();
        foreach (GameObject slot in allContent)
        {
            var itemName = slot.transform.Find("ItemName").GetComponent<Text>();
            if (itemName.ToString().Equals(target))
                return slot;
           
        }
           
        return null;
    }
}

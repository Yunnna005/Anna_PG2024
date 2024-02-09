using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using Unity.VisualScripting.FullSerializer;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    public static Inventory Instance;
    public List<Item> inventorySlots = new List<Item>();

    public Transform ItemContent; 
    public GameObject InventoryItem;

    int ItemQty = 1;
    private void Awake()
    {
        Instance = this;
        ListItems();
    }

    public void AddItem(Item item)
    {
        inventorySlots.Add(item);
    }

    public void RemoveItem(Item item) 
    {
        inventorySlots.Remove(item);
    }

    public void ListItems()
    {
        foreach (Item item in inventorySlots)
        {

            GameObject existingObject = FindExistingObject(item);

            if (existingObject != null)
            {
                ItemQty++;
                var itemQty = existingObject.transform.Find("ItemQty").GetComponent<Text>(); //to find the qty of the object
                itemQty.text = ItemQty.ToString();
            }
            else
            {
                GameObject GObject = Instantiate(InventoryItem, ItemContent);
                var itemName = GObject.transform.Find("ItemName").GetComponent<Text>(); //to find the name of the object
                var itemIcon = GObject.transform.Find("ItemIcon").GetComponent<Image>(); // to find the 2d sprite of the object

                itemName.text = item.itemName;
                itemIcon.sprite = item.icon;
            }
        }
    }

    public GameObject FindExistingObject(Item item)
    {
        foreach(Transform child in ItemContent)
        {
            var itemName = child.Find("ItemName").GetComponent<Text>();
            if (itemName.text == item.itemName)
            {
                return child.gameObject;
            }
        }
        return null;
    }
}

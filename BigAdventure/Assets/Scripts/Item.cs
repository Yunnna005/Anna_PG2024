using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class Item : ScriptableObject
{

    public int id;
    public string itemName;
    public string description;
    public int itemValue;
    public Sprite icon;
}

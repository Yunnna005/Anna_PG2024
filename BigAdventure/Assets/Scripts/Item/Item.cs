using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class Item : ScriptableObject
{
    public int id;
    public string itemName;
    public string description;
    public float itemValue;
    public bool damage;
    public bool heal;
    public bool progress;
    public Sprite icon;

}

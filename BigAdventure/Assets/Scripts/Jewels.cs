using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jewels:Item
{
    public Jewels(string JewelName)
    {
        name = JewelName;
        description = "Valuable gem, use to buy items";
    }
}

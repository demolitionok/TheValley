using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct PlayerData
{
    public float money;
    public Item equippedItem;
    public Inventory inventory;

    public PlayerData(float money, Item equippedItem, Inventory inventory)
    {
        this.money = money;
        this.equippedItem = equippedItem;
        this.inventory = inventory;
    }
}

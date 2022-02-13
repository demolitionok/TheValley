using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public struct PlayerData
{
    public float money;
    public Item equippedItem;
    public ItemList inventory;

    public PlayerData(float money, Item equippedItem, ItemList inventory)
    {
        this.money = money;
        this.equippedItem = equippedItem;
        this.inventory = inventory;
    }
}

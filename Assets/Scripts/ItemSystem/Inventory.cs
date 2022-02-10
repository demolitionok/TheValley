using System.Collections;
using System;
using UnityEngine;
using System.Collections.Generic;

[Serializable]
public class Inventory
{
    public event Action<List<Item>> OnInventoryChange;
    private List<Item> items;

    public List<Item> GetItems() => items;

    public void AddItem(Item item) 
    {
        items.Add(item);
        OnInventoryChange?.Invoke(items);
    }
    public void RemoveItem(Item item)
    {
        items.Remove(item);
        OnInventoryChange?.Invoke(items);
    }
    public void RemoveItemAt(int index)
    {
        items.RemoveAt(index);
        OnInventoryChange?.Invoke(items);
    }

    public Inventory() 
    {
        items = new List<Item>();
    }
    public Inventory(List<Item> items)
    {
        this.items = items;
    }
}

using System.Collections;
using System;
using UnityEngine;
using System.Collections.Generic;

[Serializable]
public class ItemList
{
    public event Action<List<Item>> OnChange;
    private List<Item> items;

    public List<Item> GetItems() => items;

    public void AddItem(Item item) 
    {
        items.Add(item);
        OnChange?.Invoke(items);
    }
    public void RemoveItem(Item item)
    {
        items.Remove(item);
        OnChange?.Invoke(items);
    }
    public void RemoveItemAt(int index)
    {
        items.RemoveAt(index);
        OnChange?.Invoke(items);
    }

    public void DisposeEvent() => OnChange = null;

    public ItemList() 
    {
        items = new List<Item>();
    }
    public ItemList(List<Item> items)
    {
        this.items = items;
    }
}

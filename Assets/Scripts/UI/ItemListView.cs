using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemListView : MonoBehaviour
{
    public List<ItemView> elems;
    private ItemList itemList;


    public void OnPlayerLoad(Player player) 
    {
        itemList = player.GetPlayerData().inventory;
        InitView();
    }

    private void InitView()
    {
        var items = itemList.GetItems();
        ChangeNodesItems(items);
    }

    public void OnEnable()
    {
        if (itemList != null)
        {
            InitView();
            itemList.OnChange += ChangeNodesItems;
        }
    }

    public void OnDisable()
    {
        itemList.OnChange -= ChangeNodesItems;
    }

    public void ChangeNodesItems(List<Item> items)
    {
        if (items == null)
            return;

        Debug.Log("changed");
        for (int i = 0; i < elems.Count; i++) 
        {
            if(i < items.Count)
                elems[i].SetItem(items[i]);
        }
    }
}

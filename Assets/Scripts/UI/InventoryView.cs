using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InventoryView : MonoBehaviour
{
    [SerializeField]
    private List<InventoryNode> nodes;
    private Inventory inventory;


    public void OnPlayerLoad(Player player) 
    {
        inventory = player.GetPlayerData().inventory;
        InitView();
    }

    private void InitView()
    {
        var items = inventory.GetItems();
        ChangeNodesItems(items);
    }

    public void OnEnable()
    {
        if (inventory != null)
        {
            InitView();
            Debug.Log("sub");
            inventory.OnInventoryChange += ChangeNodesItems;
        }
    }

    public void OnDisable()
    {
        Debug.Log("unsub");
        inventory.OnInventoryChange -= ChangeNodesItems;
    }

    public void ChangeNodesItems(List<Item> items)
    {
        if (items == null)
            return;

        Debug.Log("changed");
        for (int i = 0; i < nodes.Count; i++) 
        {
            if(i < items.Count)
                nodes[i].SetItem(items[i]);
        }
    }
}

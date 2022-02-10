using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryView : MonoBehaviour
{
    [SerializeField]
    private List<InventoryNode> nodes;

    public void OnPlayerInstantiate(Player player) 
    {
        var startItems = player.GetPlayerData().inventory.GetItems();
        ChangeNodesItems(startItems);
        player.AddInventoryListener(ChangeNodesItems);
    }

    public void ChangeNodesItems(List<Item> items) 
    {
        for (int i = 0; i < nodes.Count; i++) 
        {
            nodes[i].SetItem(items[i]);
        }
    }
}

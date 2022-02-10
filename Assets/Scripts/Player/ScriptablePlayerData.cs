using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class ScriptablePlayerData : ScriptableObject
{
    [SerializeField]
    private float money;
    [SerializeField]
    private Item equippedItem;
    [SerializeField]
    private List<Item> items;

    public PlayerData GetPlayerData() 
    {
        var inventory = new Inventory(items);
        return new PlayerData(money, equippedItem, inventory);
    }
}

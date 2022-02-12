using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

[CreateAssetMenu]
public class ScriptablePlayerData : ScriptableObject
{
    [SerializeField]
    private float money;
    [SerializeField]
    private Item equippedItem;
    [SerializeField]
    private List<Item> items;

    private ScriptablePlayerData Copy() 
    {
        var pd = Instantiate(this);
        pd.equippedItem = Instantiate(equippedItem);
        pd.items = pd.items.Select((x) => Instantiate(x)).ToList();
        return pd;
    }

    public PlayerData GetPlayerData() 
    {
        var copy = Copy();
        var inventory = new Inventory(copy.items);
        return new PlayerData(money, copy.equippedItem, inventory);
    }
}

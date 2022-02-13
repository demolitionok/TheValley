using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryNode : MonoBehaviour, IItemView
{
    [SerializeField]
    private Text priceText;
    [SerializeField]
    private Image itemIcon;
    public Item item { get; private set; }

    public void SetItem(Item item) 
    {
        this.item = item;
        UpdateUI();
    }

    private void UpdateUI()
    {
        if (item == null)
        {
            itemIcon.enabled = true;
            priceText.text = "NULL";
            return;
        }

        itemIcon.enabled = true;
        var text = item.price.ToString();
        priceText.text = text;
        itemIcon.sprite = item.icon;
    }
}

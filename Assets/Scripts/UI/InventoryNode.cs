using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryNode : MonoBehaviour
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
        priceText.text = item.price.ToString();
        itemIcon.sprite = item.icon;
    }
}

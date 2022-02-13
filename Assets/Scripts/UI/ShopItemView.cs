using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopItemView : MonoBehaviour, IItemView
{
    [SerializeField]
    private Text nameText;
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
            gameObject.SetActive(false);
            priceText.text = "NULL";
            return;
        }

        var text = item.price.ToString();
        priceText.text = text;
        itemIcon.sprite = item.icon;
        nameText.text = item.name;
    }

}

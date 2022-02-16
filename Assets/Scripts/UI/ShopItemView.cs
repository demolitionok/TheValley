using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class ShopItemView : ItemView
{
    [SerializeField]
    private Text nameText;
    [SerializeField]
    private Text priceText;
    [SerializeField]
    private Image itemIcon;
    [SerializeField]
    private Button buyButton;

    public event Action<Item> OnBuyClick;

    public Item item { get; private set; }


    private void InvokeOnBuyClick() 
    {
        OnBuyClick?.Invoke(item);
    }
    private void OnEnable()
    {
        buyButton.onClick.AddListener(InvokeOnBuyClick);
    }
    private void OnDisable()
    {
        buyButton.onClick.AddListener(InvokeOnBuyClick);
    }

    public override void SetItem(Item item)
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

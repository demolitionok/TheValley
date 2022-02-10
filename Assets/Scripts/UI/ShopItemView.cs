using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopItemView : MonoBehaviour
{
    [SerializeField]
    private Text nameText;
    [SerializeField]
    private Text priceText;
    [SerializeField]
    private Image itemIcon;
    [SerializeField]
    private Item sourceItem;

    void Start()
    {
        nameText.text = sourceItem.itemName;
        priceText.text = sourceItem.price.ToString();
        itemIcon.sprite = sourceItem.icon;
    }
}

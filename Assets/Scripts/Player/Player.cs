using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using System;

public class Player : MonoBehaviour
{
    [SerializeField]
    private SpriteRenderer spriteRenderer;
    private PlayerData data;

    public event Action<float> OnMoneyChanged;
    public event Action<Item> OnItemEquiped;

    public void LoadData(PlayerData data) 
    {
        this.data = data;
        EquipItem(data.equippedItem);
        InitInventory(data.inventory);
        SetMoney(data.money);
    }

    public PlayerData GetPlayerData() => data;

    public void PickUpItem(Item item) 
    {
        data.inventory.AddItem(item);
    }

    public void BuyItem(Item item) 
    {

        if (data.money - item.price >= 0)
        {
            PickUpItem(item);
            data.money -= item.price;
        }
    }

    private void InitInventory(ItemList inventory) 
    {
        data.inventory = inventory;
    }

    public void EquipItem(Item item) 
    {
        if (item.equipable)
        {
            data.equippedItem = item;
            spriteRenderer.sprite = item.sprite;
            OnItemEquiped?.Invoke(item);
        }
    }

    public void SetMoney(float newValue) 
    {
        data.money = newValue;
        OnMoneyChanged?.Invoke(newValue);
    }

    private void OnDestroy()
    {
        data.inventory.DisposeEvent();
        OnMoneyChanged = null;
        OnItemEquiped = null;
        SceneLoader.instance.savedData = data;
        Debug.Log("Saved.");
    }
}

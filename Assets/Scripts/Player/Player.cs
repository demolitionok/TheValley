using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using System;

public class Player : MonoBehaviour
{
    [SerializeField]
    private SpriteRenderer spriteRenderer;
    private PlayerData playerData;

    public event Action<float> OnMoneyChanged;
    public event Action<Item> OnItemEquiped;


    public void AddInventoryListener(Action<List<Item>> listener) 
    {
        playerData.inventory.OnInventoryChange += listener;
    }
    public void RemoveInventoryListener(Action<List<Item>> listener)
    {
        playerData.inventory.OnInventoryChange -= listener;
    }

    public void LoadData(PlayerData data) 
    {
        playerData = data;
        EquipItem(data.equippedItem);
        InitInventory(data.inventory);
        SetMoney(data.money);
    }

    public PlayerData GetPlayerData() => playerData;

    public void PickUpItem(Item item) 
    {
        playerData.inventory.AddItem(item);
    }

    private void InitInventory(Inventory inventory) 
    {
        playerData.inventory = inventory;
    }

    public void EquipItem(Item item) 
    {
        playerData.equippedItem = item;
        spriteRenderer.sprite = item.sprite;
        OnItemEquiped?.Invoke(item);
    }

    public void SetMoney(float newValue) 
    {
        playerData.money = newValue;
        OnMoneyChanged?.Invoke(newValue);
    }

    private void OnDestroy()
    {
        OnMoneyChanged = null;
        OnItemEquiped = null;
        SceneLoader.instance.savedData = playerData;
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryController : MonoBehaviour
{
    public Item sword;

    public Item PotionLog;

    public PlayerWeaponController playerWeaponController;


    public ConsumableController consumableController;
    public static InventoryController Instance { get; set; }
    public List<Item> playerItems = new List<Item>();
    public InventoryUIDetails inventoryDetailsPanel;

    // Start is called before the first frame update
    void Start()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
        }

        //Weapons
        playerWeaponController = GetComponent<PlayerWeaponController>();
        //Consumables
        consumableController = GetComponent<ConsumableController>();
        GiveItem("Sword");
        GiveItem("Staff");
        GiveItem("Potion_Log");
    }

    public void GiveItem(string itemSlug)
    {
        Item item = ItemDatabase.Instance.GetItem(itemSlug);
        playerItems.Add(item);
        UIEventHandler.ItemAddedToInventory(item);
    }

    public void GiveItem(Item item)
    {
        playerItems.Add(item);
        UIEventHandler.ItemAddedToInventory(item);
    }

    public void SetItemDetails(Item item, Button selectedButton)
    {
        inventoryDetailsPanel.SetItem(item, selectedButton);
    }

    public void EquipItem(Item itemToEquip)
    {
        playerWeaponController.EquipWeapon(itemToEquip);
    }

    public void ConsumeItem(Item itemToConsume)
    {
        consumableController.ConsumeItem(itemToConsume);
    }
}

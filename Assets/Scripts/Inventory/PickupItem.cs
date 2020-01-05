using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupItem : Interactable {
    public Item ItemDrop { get; set; }
    public override void Interact()
    {
        Debug.Log("Picked up some items!");
        InventoryController.Instance.GiveItem(ItemDrop);
        Destroy(gameObject);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestCollectionGoal : QuestGoal
{
    public string ItemId { get; set; }

    public QuestCollectionGoal (Quest quest, string itemid, string description, bool isCompleted, int currentAmount, int requiredAmount)
    {
        this.Quest = quest;
        this.ItemId = itemid;
        this.Description = description;
        this.IsCompleted = isCompleted;
        this.CurrentAmount = currentAmount;
        this.RequiredAmount = requiredAmount;
    }

    public override void Initialize()
    {
        base.Initialize();
        UIEventHandler.OnItemAddedToInventory += ItemPickedUp;
    }

    void ItemPickedUp (Item item)
    {
        if (item.ObjectSlug == this.ItemId)
        {
            Debug.Log("Picked up quest item: " + ItemId);
            this.CurrentAmount++;
            CheckComplete();
        }
    }
}

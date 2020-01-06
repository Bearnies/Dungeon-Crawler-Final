using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Quest : MonoBehaviour
{
    public List<QuestGoal> QuestGoals { get; set; } = new List<QuestGoal>();
    public string QuestName { get; set; }
    public string QuestDescription { get; set; }
    public int ExperienceReward { get; set; }
    public Item ItemReward { get; set; }
    public bool IsCompleted { get; set; }

    public void CheckQuestGoals()
    {
        IsCompleted = QuestGoals.All(goal => goal.IsCompleted); //Check if all QuestGoals are completed
    }

    public void RewardPlayer()
    {
        if (ItemReward != null)
        {
            InventoryController.Instance.GiveItem(ItemReward);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestGiver : NPC
{
    public bool AssignedQuest { get; set; }
    public bool NPCHelped { get; set; }
    private Quest Quest { get; set; }

    [SerializeField] private GameObject quests;
    [SerializeField] private string questType;

    public override void Interact()
    {
        base.Interact();
        if (!AssignedQuest && !NPCHelped)
        {
            //Give quest to Player
            AssignQuest();
        }
        else if (AssignedQuest && NPCHelped)
        {
            //Check if quest is completed
            CheckQuest();
        }
        else
        {

        }
    }

    private void CheckQuest()
    {
        if (Quest.IsCompleted)
        {
            Quest.RewardPlayer();
            NPCHelped = true;
            AssignedQuest = false;
        }
    }

    private void AssignQuest()
    {
        AssignedQuest = true;
        Quest = (Quest)quests.AddComponent(System.Type.GetType(questType));
    }
}

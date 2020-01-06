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
        if (!AssignedQuest && !NPCHelped)
        {
            base.Interact();
            //Give quest to Player
            AssignQuest();
        }
        else if (AssignedQuest && !NPCHelped)
        {
            //Check if quest is completed
            CheckQuest();
        }
        else
        {
            Dialogue.Instance.AddNewDialogue(name, new string[] {"Hey it's you, thanks again for chasing the monsters away that time !" });
        }
    }

    private void CheckQuest()
    {
        if (Quest.IsCompleted)
        {
            Quest.RewardPlayer();
            NPCHelped = true;
            AssignedQuest = false;
            Dialogue.Instance.AddNewDialogue(name, new string[] {"Thanks for chasing them away ! Take this as my appreciation !"});
        }
        else
        {
            Dialogue.Instance.AddNewDialogue(name, new string[] {"They're still out there, please help me chase them away !"});
        }
    }

    private void AssignQuest()
    {
        AssignedQuest = true;
        Quest = (Quest)quests.AddComponent(System.Type.GetType(questType));
    }
}

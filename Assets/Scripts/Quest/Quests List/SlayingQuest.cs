using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlayingQuest : Quest
{
    // Start is called before the first frame update
    void Start()
    {
        QuestName = "Slaying Quest";
        QuestDescription = "Monsters are everywhere, slay some of them !";
        ItemReward = ItemDatabase.Instance.GetItem("Potion_Log");

        QuestGoals = new List<QuestGoal>
        {
            new QuestKillGoal(this, 0, "Kill 1 Slime", false, 0, 1),
            new QuestKillGoal(this, 1, "Kill 1 Spitfire", false, 0, 1)
            //new QuestCollectionGoal(this, "Potion_Log", "Find a Potion Log", false, 0, 1)
            //QuestGoals.Add(new QuestCollectionGoal(this, "Potion_Log", "Find a Potion Log", false, 0, 1));
        };
        QuestGoals.ForEach(g => g.Initialize());
    }
}

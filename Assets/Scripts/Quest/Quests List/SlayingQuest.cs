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

        QuestGoals.Add(new QuestKillGoal(this, 0, "Kill 5 Slimes", false, 0, 5));
        QuestGoals.Add(new QuestKillGoal(this, 1, "Kill 1 Spitfire", false, 0, 2));

        QuestGoals.ForEach(g => g.Initialize());
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestGoal
{
    public Quest Quest { get; set; }
    public string Description { get; set; }
    public bool IsCompleted { get; set; }
    public int RequiredAmount { get; set; }
    public int CurrentAmount { get; set; }

    public void CheckComplete()
    {
        if (CurrentAmount >= RequiredAmount)
        {
            IsCompleted = true;
        }
    }

    public void QuestComplete()
    {
        Quest.CheckQuestGoals();
        IsCompleted = true;
        Debug.Log("Quest is completed !");
    }

    public virtual void Initialize()
    {
        Debug.Log("Initialize Quest !");
    }
}

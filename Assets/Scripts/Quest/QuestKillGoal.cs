using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestKillGoal : QuestGoal
{
    public int EnemyId { get; set; }

    public QuestKillGoal (Quest quest, int enemyid, string description, bool isCompleted, int currentAmount, int requiredAmount)
    {
        this.EnemyId = enemyid;
        this.Description = description;
        this.IsCompleted = isCompleted;
        this.CurrentAmount = currentAmount;
        this.RequiredAmount = requiredAmount;
    }

    public override void Initialize()
    {
        base.Initialize();
        CombatEvents.OnEnemyDeath += EnemyDied;
    }

    void EnemyDied (IEnemy enemy)
    {
        if (enemy.Id == this.EnemyId)
        {
            this.CurrentAmount++;
            CheckComplete();
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharactersStats : MonoBehaviour
{
    public List<BaseStats> stats = new List<BaseStats>();

    public CharactersStats(int attack, int defense, int attackSpeed)
    {
        stats = new List<BaseStats>()
        {
            new BaseStats(BaseStats.BaseStatType.Attack, attack, "Attack"),
            new BaseStats(BaseStats.BaseStatType.Defense, defense, "Defense"),
            new BaseStats(BaseStats.BaseStatType.AttackSpeed, attackSpeed, "Attack Speed")
        };
    }

    public BaseStats GetStat(BaseStats.BaseStatType stat)
    {
        return this.stats.Find(x => x.StatType == stat);
    }

    public void AddBonusStats(List<BaseStats> bonusStats) //Add Bonus stats from equipments
    {
        foreach(BaseStats bonusStat in bonusStats)
        {
            GetStat(bonusStat.StatType).AddBonusStats(new BonusStats(bonusStat.BaseValue));
        }
    }

    public void RemoveBonusStats(List<BaseStats> bonusStats) //Remove Bonus stats from equipments if switch equipments
    {
        foreach (BaseStats bonusStat in bonusStats)
        {
            GetStat(bonusStat.StatType).RemoveBonusStats(new BonusStats(bonusStat.BaseValue));
        }
    }
}

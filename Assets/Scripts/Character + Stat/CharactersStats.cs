using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharactersStats : MonoBehaviour
{
    public List<BaseStats> stats = new List<BaseStats>();

    // Start is called before the first frame update
    void Start()
    {
        stats.Add(new BaseStats(4, "Attack", "Your attack power"));
        stats.Add(new BaseStats(0, "Defense", "Your defense power"));
        stats.Add(new BaseStats(100, "Health Point", "Your health"));
        stats.Add(new BaseStats(100, "Mana Point", "Your mana"));
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddBonusStats(List<BaseStats> bonusStats) //Add Bonus stats from equipments
    {
        foreach(BaseStats bonusStat in bonusStats)
        {
            stats.Find(x => x.StatName == bonusStat.StatName).AddBonusStats(new BonusStats(bonusStat.BaseValue));
        }
    }

    public void RemoveBonusStats(List<BaseStats> bonusStats) //Remove Bonus stats from equipments if switch equipments
    {
        foreach (BaseStats bonusStat in bonusStats)
        {
            stats.Find(x => x.StatName == bonusStat.StatName).RemoveBonusStats(new BonusStats(bonusStat.BaseValue));
        }
    }
}

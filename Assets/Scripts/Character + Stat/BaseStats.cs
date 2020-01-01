using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

public class BaseStats : MonoBehaviour
{
    public enum BaseStatType { Attack, Defense, AttackSpeed }

    public List<BonusStats> BaseAdditives { get; set; }
    [JsonConverter(typeof(StringEnumConverter))]
    public BaseStatType StatType { get; set; }
    public int BaseValue { get; set; } //Startup Stats
    public int FinalValue { get; set; } //Final Stats with bonus from equipments
    public string StatName { get; set; }
    public string StatDescription { get; set; }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public BaseStats(int baseValue, string statName, string statDescription)
    {
        this.BaseAdditives = new List<BonusStats>();
        this.BaseValue = baseValue;
        this.StatName = statName;
        this.StatDescription = statDescription;
    }

    [Newtonsoft.Json.JsonConstructor]
    public BaseStats(BaseStatType statType, int baseValue, string statName)
    {
        this.BaseAdditives = new List<BonusStats>();
        this.StatType = statType;
        this.BaseValue = baseValue;
        this.StatName = statName;
    }

    public void AddBonusStats(BonusStats bonusStats)
    {
        this.BaseAdditives.Add(bonusStats);
    }

    public void RemoveBonusStats(BonusStats bonusStats)
    {
        this.BaseAdditives.Remove(bonusStats);
    }

    public int GetCalculatedValue()
    {
        this.FinalValue = 0; //Reinitialize FinalValue so it won't act outside of this (Keep adding up during pre-session)
        this.BaseAdditives.ForEach(x => this.FinalValue += x.BonusValue);
        this.FinalValue += BaseValue;
        return FinalValue;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerInfo : MonoBehaviour
{
    [SerializeField] private Text health, level;
    [SerializeField] private Image healthFill, levelFill;
    [SerializeField] private Player player;

    //Init
    void Awake()
    {
        UIEventHandler.OnPlayerHealthChanged += UpdateHealth;
    }

    // Start is called before the first frame update
    void Start()
    {
        //UIEventHandler.OnPlayerHealthChanged += UpdateHealth;
        //UIEventHandler.OnStatsChanged += UpdateStats;
        UIEventHandler.OnPlayerLevelChange += UpdateLevel;
    }

    public void UpdateHealth(int currentHealth, int maxHealth)
    {
        this.health.text = currentHealth.ToString();
        this.healthFill.fillAmount = (float)currentHealth / (float)maxHealth;
    }

    void UpdateLevel()
    {  
        this.level.text = player.PlayerLevel.Level.ToString();
        this.levelFill.fillAmount = (float)player.PlayerLevel.CurrentExperience / (float)player.PlayerLevel.RequiredExperience;
    }
}

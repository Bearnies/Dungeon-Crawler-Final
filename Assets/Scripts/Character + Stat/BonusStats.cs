using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonusStats
{
    public int BonusValue { get; set; }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public BonusStats(int bonusValue)
    {
        this.BonusValue = bonusValue;
        Debug.Log("New stat bonus initiated !");
    }
}

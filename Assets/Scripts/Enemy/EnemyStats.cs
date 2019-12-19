using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStats : CharacterStats
{
    // Start is called before the first frame update
    void Start()
    {
        health = 25;
        maxhealth = 25;

        mana = 0;
        maxmana = 0;

        damage = 8;

        attackSpeed = 1f;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public override void Die()
    {
        Destroy(gameObject, 0f);
    }
}

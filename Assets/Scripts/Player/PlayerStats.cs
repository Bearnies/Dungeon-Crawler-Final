using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerStats : CharacterStats
{
    // Start is called before the first frame update
    void Start()
    {
        health = 100;
        maxhealth = 100;

        mana = 100;
        maxmana = 100;

        damage = 25;

        attackSpeed = 1f;
    }

    //If player dies, player can no longer move
    public override void Die()
    {
        SceneManager.LoadScene(0);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterCombat : MonoBehaviour
{ 
    public CharacterStats myStats;

    public float attackCooldown; //Attacks need cooldown, otherwise, the enemies can kill the player really fast and vice versa
    bool canAttack = true;

    // Start is called before the first frame update
    void Start()
    {
        myStats = GetComponent<CharacterStats>();
    }

    // Update is called once per frame
    void Update()
    {
        if (canAttack == false)
        {
            attackCooldown -= Time.deltaTime;
            if (attackCooldown <= 0)
            {
                canAttack = true;
            }
        }
    }

    public void MeleeAttack(CharacterStats targetStats)
    {
        if (attackCooldown <= 0)
        {
            targetStats.takeDamage(myStats.damage);
            attackCooldown = 1 / myStats.attackSpeed;
            canAttack = false;
        }
    }
}

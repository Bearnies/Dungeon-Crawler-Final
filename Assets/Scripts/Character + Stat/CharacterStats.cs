using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//This is for both enemies and player
public class CharacterStats : MonoBehaviour
{
    public int health = 100;
    public int maxhealth = 100;

    public int mana = 100;
    public int maxmana = 100;

    public int damage;

    public float attackSpeed;

    bool isDead = false;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
       
    }

    public virtual void Die()
    {
        //Overwritten by PlayerStats & EnemyStats
    }

    public void checkHealth() //Make sure player won't heal above 100 HP
    {
        if (health <= 0)
        {
            health = 0;
            isDead = true;
            if (isDead == true)
            {
                Die();
            }
        }
        if (health >= maxhealth)
        {
            health = maxhealth;
        }
    }

    public void checkMana() //Make sure player won't recover above 100 MP
    {
        if (mana <= 0)
        {
            mana = 0;
        }
        if (mana >= maxmana)
        {
            mana = maxmana;
        }
    }

    public void takeDamage(int damageTaken)
    {
        health -= damageTaken;
        checkHealth();
    }
}

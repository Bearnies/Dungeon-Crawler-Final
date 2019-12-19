using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    float radius = 2f; //Radius of enemy, enemy will attack player if the player is in the radius

    GameObject player;

    CharacterStats myStats;
    NavMeshAgent navAgent;

    // Start is called before the first frame update
    void Start()
    {
        player = PlayerManager.instance.player;
        myStats = GetComponent<CharacterStats>();
        navAgent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector3.Distance(transform.position, player.transform.position);

        if (Input.GetKeyDown(KeyCode.Q))
        {
            if (distance <= radius)
            {
                CharacterCombat playerCombat = player.GetComponent<CharacterCombat>();

                if (playerCombat != null)
                {
                    playerCombat.MeleeAttack(myStats);
                }
            }
        }

        if (distance <= navAgent.stoppingDistance)
        {
            StartCoroutine("EnemyMeleeAttack");
            //CharacterCombat myCombat = GetComponent<CharacterCombat>();
            //CharacterStats playerStats = player.GetComponent<CharacterStats>();
            //myCombat.MeleeAttack(playerStats);
        }
    }

    IEnumerator EnemyMeleeAttack()
    {
        yield return new WaitForSeconds(1f / myStats.attackSpeed);

        CharacterCombat myCombat = GetComponent<CharacterCombat>();
        CharacterStats playerStats = player.GetComponent<CharacterStats>();
        myCombat.MeleeAttack(playerStats);
        yield break;
    }
}

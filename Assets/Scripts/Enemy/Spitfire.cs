using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Spitfire : MonoBehaviour, IEnemy
{
    public LayerMask aggroLayerMask;
    public float currentHealth;
    public float maxHealth;
    public int Id { get; set; }
    public MonsterSpawner MonsterSpawner { get; set; }
    public int Experience { get; set; }
    public DropTable DropTable { get; set; }
    public PickupItem pickupItem;

    private Player player;
    private NavMeshAgent navAgent;
    private CharactersStats charactersStats;
    private Collider[] withinAggroColliders;

    // Start is called before the first frame update
    void Start()
    {
        DropTable = new DropTable();
        DropTable.loot = new List<LootDrop>
        {
            //25% Drop chance
            new LootDrop("Potion_Log", 25)
        };

        Id = 1;
        Experience = 150;
        navAgent = GetComponent<NavMeshAgent>();
        charactersStats = new CharactersStats(8, 7, 4);
        currentHealth = maxHealth;
    }

    void FixedUpdate()
    {
        withinAggroColliders = Physics.OverlapSphere(transform.position, 10, aggroLayerMask); //Radius = 10f
        if (withinAggroColliders.Length > 0)
        {
            ChasePlayer(withinAggroColliders[0].GetComponent<Player>());
        }
    }

    public void PerformAttack()
    {
        player.TakeDamage(10);
    }

    public void TakeDamage(int damageTaken)
    {
        currentHealth -= damageTaken;
        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void ChasePlayer(Player player)
    {
        navAgent.SetDestination(player.transform.position);
        this.player = player;
        if (navAgent.remainingDistance <= navAgent.stoppingDistance)
        {
            if (!IsInvoking("PerformAttack"))
            {
                InvokeRepeating("PerformAttack", .5f, 2f); //Time = 0.5f, RepeatRate = 2f (Attack every 2 secs)
            }
        }
        else
        {
            CancelInvoke("PerformAttack");
        }
    }

    public void Die()
    {
        DropLoot();
        CombatEvents.EnemyDied(this);
        this.MonsterSpawner.RespawnMonster();
        Destroy(gameObject);
    }

    void DropLoot()
    {
        Item item = DropTable.GetDrop();
        if (item != null)
        {
            PickupItem instance = Instantiate(pickupItem, transform.position, Quaternion.identity);
            instance.ItemDrop = item;
        }
    }
}

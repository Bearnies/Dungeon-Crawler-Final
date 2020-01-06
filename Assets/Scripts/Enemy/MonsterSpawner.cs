using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterSpawner : MonoBehaviour
{
    public GameObject monster;
    public bool respawn;
    private float currentTime;
    public float spawnDelay;
    private bool isSpawning;

    // Start is called before the first frame update
    void Start()
    {
        SpawnMonster();
        currentTime = spawnDelay;
    }

    // Update is called once per frame
    void Update()
    {
        if (isSpawning)
        {
            currentTime -= Time.deltaTime;
            if (currentTime <= 0)
            {
                SpawnMonster();
            }
        }
    }

    void SpawnMonster()
    {
        IEnemy enemy = Instantiate(monster, transform.position, Quaternion.identity).GetComponent<IEnemy>();
        enemy.MonsterSpawner = this;
        isSpawning = false;
    }

    public void RespawnMonster()
    {
        isSpawning = true;
        currentTime = spawnDelay;
    }
}

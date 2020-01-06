using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IEnemy
{
    int Id { get; set; }
    int Experience { get; set; }
    MonsterSpawner MonsterSpawner { get; set; }

    void Die();
    void TakeDamage(int damageTaken);
    void PerformAttack();
}

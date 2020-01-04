using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Staff : MonoBehaviour, IProjectileWeapon, IWeapon
{
    private Animator animator;

    public List<BaseStats> Stats { get; set; }

    public Transform ProjectileSpawn { get; set; }

    Fireball fireBall;

    public int CurrentDamage  { get; set; }

    // Start is called before the first frame update
    void Start()
    {
        fireBall = Resources.Load<Fireball>("Weapons/Projectiles/Fireball");
        animator = GetComponent<Animator>();
    }

    public void PerformAttack(int damage)
    {
        CurrentDamage = damage;
        animator.SetTrigger("Base_Attack");
    }

    public void PerformSpecialAttack()
    {
        animator.SetTrigger("Special_Attack");
    }

    public void CastProjectile()
    {
        Fireball fireballInstance = (Fireball)Instantiate(fireBall, ProjectileSpawn.position, transform.rotation);
        fireballInstance.Direction = ProjectileSpawn.forward;
    }
}

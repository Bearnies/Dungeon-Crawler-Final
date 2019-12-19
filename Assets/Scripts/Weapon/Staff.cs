using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Staff : MonoBehaviour, IWeapon, IProjectileWeapon
{
    private Animator animator;

    public List<BaseStats> Stats { get; set; }

    public Transform ProjectileSpawn { get; set; }

    Fireball fireBall;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        fireBall = Resources.Load<Fireball>("Weapons/Projectiles/Fireball");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PerformAttack()
    {
        animator.SetTrigger("Base_Attack");
    }

    public void PerformSpecialAttack()
    {
        animator.SetTrigger("Special_Attack");
    }

    void OnTriggerEnter(Collider collider)
    {
        if (collider.tag == "Enemy")
        {
            collider.GetComponent<IEnemy>().TakeDamage(Stats[0].GetCalculatedValue());
        }
    }

    public void CastProjectile()
    {
        Fireball fireballInstance = (Fireball)Instantiate(fireBall, ProjectileSpawn.position, transform.rotation);
        fireballInstance.Direction = ProjectileSpawn.forward;
    }
}

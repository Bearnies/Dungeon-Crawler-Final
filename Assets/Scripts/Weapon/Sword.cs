using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword : MonoBehaviour, IWeapon
{
    public List<BaseStats> Stats { get; set; }
    private Animator animator;
    public CharactersStats charactersStats { get; set; }

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PerformAttack()
    {
        //Debug.Log("Sword Attack !");
        animator.SetTrigger("Base_Attack");
    }

    public void PerformSpecialAttack()
    {
        //Debug.Log("Special Attack !");
        animator.SetTrigger("Special_Attack");
    }

    void OnTriggerEnter(Collider collider)
    {
        if (collider.tag == "Enemy")
        {
            collider.GetComponent<IEnemy>().TakeDamage(charactersStats.GetStat(BaseStats.BaseStatType.Attack).GetCalculatedValue());
        }
    }
}

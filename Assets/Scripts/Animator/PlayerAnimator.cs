using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerAnimator : MonoBehaviour
{
    const float locomationSmoothTime = .1f;

    NavMeshAgent navAgent;
    Animator animator;

    AnimatorOverrideController overrideController;

    // Start is called before the first frame update
    void Start()
    {
        navAgent = GetComponent<NavMeshAgent>();
        animator = GetComponentInChildren<Animator>();
        //swordCombat = GetComponent<Sword>();

        //overrideController = new AnimatorOverrideController(animator.runtimeAnimatorController);
        //animator.runtimeAnimatorController = overrideController;
    }

    // Update is called once per frame
    void Update()
    {
        float speedPercent = navAgent.velocity.magnitude / navAgent.speed;
        animator.SetFloat("speedPercent", speedPercent, locomationSmoothTime, Time.deltaTime);
        //animator.SetBool("inCombat", swordCombat.InCombat);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            animator.SetTrigger("attack");
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAnimator : MonoBehaviour
{
    const float locomationSmoothTime = .1f;

    NavMeshAgent navAgent;
    Animator animator;

    AnimatorOverrideController overrideController;

    Transform player;

    // Start is called before the first frame update
    void Start()
    {
        navAgent = GetComponent<NavMeshAgent>();
        animator = GetComponentInChildren<Animator>();
        player = GameObject.FindWithTag("Player").GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        float speedPercent = navAgent.velocity.magnitude / navAgent.speed;
        animator.SetFloat("speedPercent", speedPercent, locomationSmoothTime, Time.deltaTime);

        //If Player's in range. Trigger the attack animation
        if (Vector3.Distance(player.position, transform.position) <= navAgent.stoppingDistance)
        {
            animator.SetTrigger("attack");
        }
    }
}

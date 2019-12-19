using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMovement : MonoBehaviour
{
    public Transform target; //Player's current position

    NavMeshAgent navAgent;

    // Start is called before the first frame update
    void Start()
    {
        navAgent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector3.Distance(transform.position, target.position); //Calculate the distance between the enemy and the player

        if (distance <= navAgent.stoppingDistance)
        {
            Vector3 direction = (target.position - transform.position).normalized; //Set the direction for the enemy
            Quaternion lookDirection = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z)); //Calculate the look direction towards the player
            transform.rotation = Quaternion.Slerp(transform.rotation, lookDirection, Time.deltaTime * 10f); //Enemy's rotation to the player
        }

        navAgent.SetDestination(target.position); //Move towards player
    }
}

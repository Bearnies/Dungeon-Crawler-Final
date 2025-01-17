﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Interactable : MonoBehaviour
{
    public NavMeshAgent playerAgent;
    private bool hasInteracted;
    bool isEnemy;

    public virtual void MoveToInteraction(NavMeshAgent playerAgent)
    {
        isEnemy = gameObject.tag == "Enemy";
        hasInteracted = false;
        this.playerAgent = playerAgent;
        playerAgent.stoppingDistance = 4f;
        playerAgent.destination = GetTargetPosition();
        EnsureLookDirection();
    }

    void Update()
    {
        if (!hasInteracted && playerAgent != null && !playerAgent.pathPending)
        {
            playerAgent.destination = GetTargetPosition();
            EnsureLookDirection();
            if (playerAgent.remainingDistance <= playerAgent.stoppingDistance)
            {
                if (!isEnemy)
                    Interact();
                hasInteracted = true;
            }
        }
    }

    void EnsureLookDirection()
    {
        playerAgent.updateRotation = false;
        Vector3 lookDirection = new Vector3(transform.position.x, playerAgent.transform.position.y, transform.position.z);
        playerAgent.transform.LookAt(lookDirection);
        playerAgent.updateRotation = true;
    }

    public virtual void Interact()
    {
        Debug.Log("Interacting !");
    }

    private Vector3 GetTargetPosition()
    {
        return transform.position;
    }
}

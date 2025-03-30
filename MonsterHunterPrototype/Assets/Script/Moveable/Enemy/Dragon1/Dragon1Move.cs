using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Dragon1Move : MovingObject
{
    public GameObject target;

    private NavMeshAgent nmAgent;

    protected override void Start()
    {
        nmAgent = GetComponent<NavMeshAgent>();
        nmAgent.speed = moveSpeed;
        base.Start();
    }

    public void Move()
    {
        nmAgent.isStopped = false;
        nmAgent.SetDestination(target.transform.position);
    }

    public bool IsMovingStopped()
    {
        return nmAgent.velocity.magnitude == 0f;
    }

    public void StopMoving()
    {
        nmAgent.isStopped = true;
    }

}

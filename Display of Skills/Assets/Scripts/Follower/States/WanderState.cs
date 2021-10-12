using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class WanderState : BaseState
{
    FollowerController follower;
    NavMeshAgent nav;
    FollowerVisionController vision;

    Vector3 randomPosition;
    float range = 25f;


    public WanderState(FollowerController _follower) : base(_follower.gameObject)
    {
        follower = _follower;
        nav = transform.GetComponent<NavMeshAgent>();
        vision = transform.GetComponent<FollowerVisionController>();
    }

    public override void OnStateEnter()
    {
        randomPosition = transform.position + UnityEngine.Random.insideUnitSphere * range;

        NavMeshHit hit;
        if (NavMesh.SamplePosition(randomPosition, out hit, range, NavMesh.AllAreas))
        {
            nav.SetDestination(hit.position);
        }
    }

    public override Type Tick()
    {
        if (vision.targetDetected) return typeof(ChaseState);

        bool InStoppingDistance = nav.remainingDistance <= nav.stoppingDistance;
        if (!nav.pathPending && InStoppingDistance)
            return typeof(IdleState);

        return null;
    }
}

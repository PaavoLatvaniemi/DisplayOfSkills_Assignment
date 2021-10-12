using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SearchState : BaseState
{
    FollowerController follower;
    NavMeshAgent nav;
    FollowerVisionController vision;
    FollowerFX fx;

    Vector3 randomPosition;
    float range = 4f;


    public SearchState(FollowerController _follower) : base(_follower.gameObject)
    {
        follower = _follower;
        nav = transform.GetComponent<NavMeshAgent>();
        vision = transform.GetComponent<FollowerVisionController>();
        fx = transform.GetComponent<FollowerFX>();
    }

    public override void OnStateEnter()
    {
        randomPosition = vision.detectedTargetGO.transform.position + UnityEngine.Random.insideUnitSphere * range;

        NavMeshHit hit;
        if (NavMesh.SamplePosition(randomPosition, out hit, range, NavMesh.AllAreas))
        {
            nav.SetDestination(hit.position);
        }
        fx.ChangeToSearch();
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

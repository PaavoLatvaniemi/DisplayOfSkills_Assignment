using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ChaseState : BaseState
{
    FollowerController follower;
    NavMeshAgent nav;
    FollowerVisionController vision;
    FollowerFX fx;

    Transform target;

    public ChaseState(FollowerController _follower) : base(_follower.gameObject)
    {
        follower = _follower;
        nav = transform.GetComponent<NavMeshAgent>();
        vision = transform.GetComponent<FollowerVisionController>();
        fx = transform.GetComponent<FollowerFX>();
    }

    public override void OnStateEnter()
    {
        target = vision.detectedTargetGO.transform;
        fx.ChangeToChase();
    }

    public override Type Tick()
    {
        if (!vision.LineOfSightToTarget()) return typeof(SearchState);

        nav.SetDestination(target.position);
        return null;
    }
}

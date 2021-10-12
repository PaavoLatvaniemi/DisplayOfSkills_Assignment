using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class IdleState : BaseState
{
    FollowerController follower;
    FollowerVisionController vision;
    NavMeshAgent nav;
    Timer waitTimer;
    FollowerFX fx;

    public IdleState(FollowerController _follower) : base(_follower.gameObject)
    {
        follower = _follower;
        vision = transform.GetComponent<FollowerVisionController>();
        nav = transform.GetComponent<NavMeshAgent>();
        fx = transform.GetComponent<FollowerFX>();
    }

    public override void OnStateEnter()
    {
        waitTimer = TimerFactory.CreateTimer(UnityEngine.Random.Range(1f, 3f));
        nav.ResetPath();
        fx.ChangeToIdle();
    }

    public override Type Tick()
    {
        if (vision.targetDetected)
            if(vision.LineOfSightToTarget())
                return typeof(ChaseState);

        waitTimer.Tick();
        if (waitTimer.Finished()) return typeof(WanderState);

        return null;
    }
}

using System;
using System.Collections.Generic;
using UnityEngine;

public class FollowerController : MonoBehaviour
{
    StateMachine stateMachine;

    void Start()
    {
        stateMachine = GetComponent<StateMachine>();
        InitializeStateMachine();
    }

    private void InitializeStateMachine()
    {
        var states = new Dictionary<Type, BaseState>()
        {           
            { typeof(IdleState), new IdleState(this) },
            { typeof(ChaseState), new ChaseState(this) },
            { typeof(SearchState), new SearchState(this) },
            { typeof(WanderState), new WanderState(this) },
        };

        stateMachine.SetStates(states);
    }
}

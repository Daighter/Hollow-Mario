using FrogStates;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrogIdleState : FrogState
{
    float idleTime;

    public FrogIdleState(Frog owner, StateMachine<State, Frog> stateMachine) : base(owner, stateMachine) { }

    public override void Setup()
    {
        
    }

    public override void Enter()
    {
        idleTime = 0;
    }

    public override void Update()
    {
        
    }

    public override void Transition()
    {
        
    }

    public override void Exit()
    {
        
    }
}

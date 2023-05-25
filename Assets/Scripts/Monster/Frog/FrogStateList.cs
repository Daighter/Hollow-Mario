using FrogStates;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrogFallingState : FrogState
{
    public FrogFallingState(Frog owner, StateMachine<State, Frog> stateMachine) : base(owner, stateMachine) { }

    public override void Setup()
    {

    }

    public override void Enter()
    {
        GameObject.Instantiate(gameObject, player.position * Vector2.up * 10f, transform.rotation);
        anim.SetBool("IsFalling", true);
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

public class FrogIdleState : FrogState
{
    float idleTime;

    public FrogIdleState(Frog owner, StateMachine<State, Frog> stateMachine) : base(owner, stateMachine) { }

    public override void Setup()
    {
        
    }

    public override void Enter()
    {
        anim.SetBool("IsJump", false);
        idleTime = 0;
    }

    public override void Update()
    {
        idleTime += Time.deltaTime;
    }

    public override void Transition()
    {
        if (idleTime > 2f)
        {
            idleTime = 0;
            stateMachine.ChangeState(State.Trace);
        }
    }

    public override void Exit()
    {
        
    }
}

public class FrogTraceState : FrogState
{
    public FrogTraceState(Frog owner, StateMachine<State, Frog> stateMachine) : base(owner, stateMachine) { }

    public override void Setup()
    {

    }

    public override void Enter()
    {
        isJump = true;
        anim.SetBool("IsJump", true);
    }

    public override void Update()
    {
        dir = (player.position - transform.position).normalized;
        rb.AddForce(dir * new Vector2(1, 1).normalized * jumpPower, ForceMode2D.Impulse);
    }

    public override void Transition()
    {
        if (!isJump)
        {
            stateMachine.ChangeState(State.Idle);
        }
    }

    public override void Exit()
    {

    }
}

public class FrogDieState : FrogState
{
    public FrogDieState(Frog owner, StateMachine<State, Frog> stateMachine) : base(owner, stateMachine) { }

    public override void Setup()
    {

    }

    public override void Enter()
    {

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

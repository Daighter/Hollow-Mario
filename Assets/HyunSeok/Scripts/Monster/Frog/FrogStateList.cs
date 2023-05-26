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
        rb.velocity = new Vector2(dir.x, 1).normalized * jumpPower;
    }

    public override void Update()
    {
        dir = (player.position - transform.position).normalized;
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
        rb.AddForce(Vector2.up * 3f * Time.deltaTime);
        anim.SetBool("IsDie", true);
        render.flipY = true;

        GameObject.Destroy(gameObject, 1.5f);
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

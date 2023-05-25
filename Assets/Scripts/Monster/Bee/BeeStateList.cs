using BeeStates;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleState : BeeState
{
    float idleTime;

    public IdleState(Bee owner, StateMachine<State, Bee> stateMachine) : base(owner, stateMachine) { }

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
        idleTime += Time.deltaTime;
        if (idleTime > 1.5f)
        {
            idleTime = 0;
            stateMachine.ChangeState(State.Patrol);
        }

        if (Vector2.Distance(player.position, transform.position) < attackRange
            && Vector2.Distance(player.position, transform.position) > detectRange)
        {
            stateMachine.ChangeState(State.Attack);
        }
        else if (Vector2.Distance(player.position, transform.position) < detectRange)
        {
            stateMachine.ChangeState(State.Runaway);
        }
    }

    public override void Exit()
    {

    }
}

public class PatrolState : BeeState
{
    public PatrolState(Bee owner, StateMachine<State, Bee> stateMachine) : base(owner, stateMachine) { }

    public override void Setup()
    {

    }

    public override void Enter()
    {
        patrolIndex = 0;
    }

    public override void Update()
    {
        dir = (patrolPoints[patrolIndex].position - transform.position).normalized;
        transform.Translate(dir * owner.moveSpeed * Time.deltaTime);
    }

    public override void Transition()
    {
        if (Vector2.Distance(patrolPoints[patrolIndex].position, transform.position) < 0.02f)
        {
            patrolIndex = (patrolIndex + 1) % patrolPoints.Length;
            stateMachine.ChangeState(State.Idle);
        }
        else if (Vector2.Distance(player.position, transform.position) < attackRange
            && Vector2.Distance(player.position, transform.position) > detectRange)
        {
            stateMachine.ChangeState(State.Attack);
        }
        else if (Vector2.Distance(player.position, transform.position) < detectRange)
        {
            stateMachine.ChangeState(State.Runaway);
        }
    }

    public override void Exit()
    {

    }
}

public class RunawayState : BeeState
{
    public RunawayState(Bee owner, StateMachine<State, Bee> stateMachine) : base(owner, stateMachine) { }

    public override void Setup()
    {

    }

    public override void Enter()
    {
    }

    public override void Update()
    {
        dir = (player.position - transform.position).normalized;
        transform.Translate(-dir * owner.moveSpeed * Time.deltaTime);
    }

    public override void Transition()
    {
        if (Vector2.Distance(player.position, transform.position) > detectRange)
        {
            stateMachine.ChangeState(State.Return);
        }
        else if (Vector2.Distance(player.position, transform.position) < attackRange
            && Vector2.Distance(player.position, transform.position) > detectRange)
        {
            stateMachine.ChangeState(State.Attack);
        }
        else if (Vector2.Distance(player.position, transform.position) < detectRange)
        {
            stateMachine.ChangeState(State.Runaway);
        }
    }

    public override void Exit()
    {

    }
}

public class ReturnState : BeeState
{
    public ReturnState(Bee owner, StateMachine<State, Bee> stateMachine) : base(owner, stateMachine) { }

    public override void Setup()
    {

    }

    public override void Enter()
    {
    }

    public override void Update()
    {
        dir = (returnPosition - transform.position).normalized;
        transform.Translate(dir * owner.moveSpeed * Time.deltaTime);
    }

    public override void Transition()
    {
        if (Vector2.Distance(returnPosition, transform.position) < 0.02f)
        {
            stateMachine.ChangeState(State.Idle);
        }
        else if (Vector2.Distance(player.position, transform.position) < attackRange
            && Vector2.Distance(player.position, transform.position) > detectRange)
        {
            stateMachine.ChangeState(State.Attack);
        }
        else if (Vector2.Distance(player.position, transform.position) < detectRange)
        {
            stateMachine.ChangeState(State.Runaway);
        }
    }

    public override void Exit()
    {

    }
}

public class AttackState : BeeState
{
    float attackCool;

    public AttackState(Bee owner, StateMachine<State, Bee> stateMachine) : base(owner, stateMachine) { }

    public override void Setup()
    {

    }

    public override void Enter()
    {
        attackCool = 0;
    }

    public override void Update()
    {
        attackCool += Time.deltaTime;
        if (attackCool > 0)
        {
            // TODO : 파이어볼 공격
            attackCool = 0;
        }
    }

    public override void Transition()
    {
        if (Vector2.Distance(player.position, transform.position) > attackRange)
        {
            stateMachine.ChangeState(State.Return);
        }
        else if (Vector2.Distance(player.position, transform.position) < detectRange)
        {
            stateMachine.ChangeState(State.Runaway);
        }
    }

    public override void Exit()
    {

    }
}

public class DieState : BeeState
{
    public DieState(Bee owner, StateMachine<State, Bee> stateMachine) : base(owner, stateMachine) { }

    public override void Setup()
    {

    }

    public override void Enter()
    {
        anim.SetTrigger("Die");
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

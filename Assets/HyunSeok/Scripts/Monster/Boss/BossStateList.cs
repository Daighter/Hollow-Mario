using BossStates;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class BossIdleState : BossState
{
    public BossIdleState(Boss owner, StateMachine<State, Boss> stateMachine) : base(owner, stateMachine) { }

    public override void Setup()
    {
        
    }

    public override void Enter()
    {
        attackSeqeunce = Random.Range(0, 3);
    }

    public override void Update()
    {
        dir = (player.position - transform.position).normalized;

        attackTime += Time.deltaTime;
    }

    public override void Transition()
    {
        if (Vector2.Distance(player.position, transform.position) < attackRange)
        {
            if (attackTime > 3f)
            {
                attackTime = 0;
                switch (attackSeqeunce)
                {
                    case 0:
                        rb.AddForce(Vector2.up * 5f * Time.deltaTime);
                        anim.SetTrigger("CrushAttack");
                        if (anim.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1f)
                        {
                            stateMachine.ChangeState(State.CrushAttack);
                        }
                        break;
                    case 1:
                        anim.SetTrigger("NormalAttack");
                        if (anim.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1f)
                        {
                            stateMachine.ChangeState(State.NormalAttack);
                        }
                        break;
                    case 2:
                        anim.SetTrigger("BombAttack");
                        if (anim.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1f)
                        {
                            stateMachine.ChangeState(State.BombAttack);
                        }
                        break;
                }
            }            
        }

        if (Vector2.Distance(player.position, transform.position) < detectRange
            && Vector2.Distance(player.position, transform.position) > attackRange)
        {
            stateMachine.ChangeState(State.Trace);
        }
    }

    public override void Exit()
    {
        
    }
}

public class BossCrushAttackState : BossState
{
    public BossCrushAttackState(Boss owner, StateMachine<State, Boss> stateMachine) : base(owner, stateMachine) { }

    public override void Setup()
    {
        
    }

    public override void Enter()
    {
        GameObject.Instantiate(crush, player.position + new Vector3(0, -0.2f, 0), transform.rotation);
    }

    public override void Update()
    {
        dir = (player.position - transform.position).normalized;
    }

    public override void Transition()
    {
        stateMachine.ChangeState(State.Idle);
    }

    public override void Exit()
    {
        GameObject.Destroy(crush);
    }
}

public class BossNormalAttackState : BossState
{
    public BossNormalAttackState(Boss owner, StateMachine<State, Boss> stateMachine) : base(owner, stateMachine) { }

    public override void Setup()
    {

    }

    public override void Enter()
    {
        GameObject.Instantiate(normal, dir.x * new Vector3(transform.position.x + 0.3f, transform.position.y, transform.position.z), transform.rotation);
    }

    public override void Update()
    {
        dir = (player.position - transform.position).normalized;
    }

    public override void Transition()
    {
        stateMachine.ChangeState(State.Idle);
    }

    public override void Exit()
    {
        GameObject.Destroy(normal);
    }
}

public class BossBombAttackState : BossState
{
    public BossBombAttackState(Boss owner, StateMachine<State, Boss> stateMachine) : base(owner, stateMachine) { }

    public override void Setup()
    {

    }

    public override void Enter()
    {

    }

    public override void Update()
    {
        dir = (player.position - transform.position).normalized;
    }

    public override void Transition()
    {
        stateMachine.ChangeState(State.Idle);
    }

    public override void Exit()
    {
        
    }
}

public class BossTraceState : BossState
{
    public BossTraceState(Boss owner, StateMachine<State, Boss> stateMachine) : base(owner, stateMachine) { }

    public override void Setup()
    {

    }

    public override void Enter()
    {
        anim.SetBool("IsMove", true);
    }

    public override void Update()
    {
        dir = (player.position - transform.position).normalized;
        transform.Translate(dir * owner.moveSpeed * Time.deltaTime);
    }

    public override void Transition()
    {
        if (Vector2.Distance(player.position, transform.position) < attackRange)
        {
            stateMachine.ChangeState(State.Idle);
        }

        if (Vector2.Distance(player.position, transform.position) > detectRange)
        {
            stateMachine.ChangeState(State.Idle);
        }
    }

    public override void Exit()
    {
        anim.SetBool("IsMove", false);
    }
}

public class BossDamageState : BossState
{
    public BossDamageState(Boss owner, StateMachine<State, Boss> stateMachine) : base(owner, stateMachine) { }

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

public class BossDieState : BossState
{
    public BossDieState(Boss owner, StateMachine<State, Boss> stateMachine) : base(owner, stateMachine) { }

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
using BossStates;
using System.Collections;
using System.Collections.Generic;
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
    }

    public override void Transition()
    {
        if (Vector2.Distance(player.position, transform.position) < attackRange)
        {
            switch (attackSeqeunce)
            {
                case 0:
                    anim.SetTrigger("CrushAttack");
                    if (anim.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1f)
                    {
                        stateMachine.ChangeState(State.CrushAttack);
                    }
                    break;
                case 1:
                    stateMachine.ChangeState(State.NormalAttack);
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
        crushCd.transform.position = player.position * Vector2.down * 1f;
        crushCd.enabled = true;
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
        crushCd.enabled = false;
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
        anim.SetTrigger("NormalAttack");
        attackCd.enabled = true;
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
        crushCd.enabled = false;
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
        crushCd.enabled = false;
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
        attackSeqeunce = Random.Range(0, 3);
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
            switch (attackSeqeunce)
            {
                case 0:
                    anim.SetTrigger("CrushAttack");
                    if (anim.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1f)
                    {
                        stateMachine.ChangeState(State.CrushAttack);
                    }
                    break;
                case 1:
                    stateMachine.ChangeState(State.NormalAttack);
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
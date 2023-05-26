using BossStates;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : Monster
{
    [SerializeField] private string name;
    [SerializeField] public float moveSpeed;
    [SerializeField] public GameObject crush;
    [SerializeField] public GameObject normal;

    StateMachine<State, Boss> stateMachine;

    protected override void Awake()
    {
        base.Awake();

        crush.GetComponent<Collider2D>().enabled = false;
        normal.GetComponent<Collider2D>().enabled = false;

        stateMachine = new StateMachine<State, Boss>(this);
        stateMachine.AddState(State.Idle,           new BossIdleState(this, stateMachine));
        stateMachine.AddState(State.CrushAttack,    new BossCrushAttackState(this, stateMachine));
        stateMachine.AddState(State.NormalAttack,   new BossNormalAttackState(this, stateMachine));
        stateMachine.AddState(State.BombAttack,     new BossBombAttackState(this, stateMachine));
        stateMachine.AddState(State.Trace,          new BossTraceState(this, stateMachine));
        stateMachine.AddState(State.Damage,         new BossDamageState(this, stateMachine));
        stateMachine.AddState(State.Die,            new BossDieState(this, stateMachine));
    }

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        stateMachine.Setup(State.Idle);
    }

    private void Update()
    {
        stateMachine.Update();
    }

    private void FixedUpdate()
    {
        Turn();
    }

    private void Turn()
    {
        if (dir.x < 0)
            render.flipX = true;
        else if (dir.x > 0)
            render.flipX = false;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, detectRange);
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRange);
    }
}

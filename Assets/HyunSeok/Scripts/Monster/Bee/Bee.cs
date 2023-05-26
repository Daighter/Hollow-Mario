using System.Collections;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using UnityEngine;
using BeeStates;

public class Bee : Monster
{
    [SerializeField] private string name;
    [SerializeField] public float moveSpeed;
    [SerializeField] public Transform[] patrolPoints;
    [SerializeField] public FireBall fireball;

    [HideInInspector] public int patrolIndex = 0;
    [HideInInspector] public bool isDead;

    StateMachine<State, Bee> stateMachine;

    protected override void Awake()
    {
        base.Awake();

        hp = 3;

        stateMachine = new StateMachine<State, Bee>(this);
        stateMachine.AddState(State.Idle,       new BeeIdleState(this, stateMachine));
        stateMachine.AddState(State.Patrol,     new BeePatrolState(this, stateMachine));
        stateMachine.AddState(State.Runaway,    new BeeRunawayState(this, stateMachine));
        stateMachine.AddState(State.Return,     new BeeReturnState(this, stateMachine));
        stateMachine.AddState(State.Attack,     new BeeAttackState(this, stateMachine));
        stateMachine.AddState(State.Die,        new BeeDieState(this, stateMachine));
    }

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        rb.gravityScale = 0f;
        returnPosition = transform.position;
        stateMachine.Setup(State.Idle);
    }

    private void Update()
    {
        stateMachine.Update();
        DeadCheck();
    }

    private void DeadCheck()
    {
        if (isDead)
            stateMachine.ChangeState(State.Die);
    }

    private void FixedUpdate()
    {
        Turn();
    }

    private void Turn()
    {
        if (dir.x > 0)
            render.flipX = true;
        else if (dir.x < 0)
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



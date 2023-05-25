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

    [HideInInspector] public int patrolIndex;
    [HideInInspector] public Vector3 returnPosition;

    StateMachine<State, Bee> stateMachine;

    protected override void Awake()
    {
        base.Awake();

        stateMachine = new StateMachine<State, Bee>(this);
        stateMachine.AddState(State.Idle,       new IdleState(this, stateMachine));
        stateMachine.AddState(State.Patrol,     new PatrolState(this, stateMachine));
        stateMachine.AddState(State.Runaway,    new RunawayState(this, stateMachine));
        stateMachine.AddState(State.Return,     new ReturnState(this, stateMachine));
        stateMachine.AddState(State.Attack,     new AttackState(this, stateMachine));
        stateMachine.AddState(State.Die,        new DieState(this, stateMachine));
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



using FrogStates;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Frog : Monster
{
    [SerializeField] private string name;
    [SerializeField] public float jumpPower;
    [SerializeField] private LayerMask layerMask;

    [HideInInspector] public bool isJump;
    StateMachine<State, Frog> stateMachine;

    protected override void Awake()
    {
        base.Awake();

        stateMachine = new StateMachine<State, Frog>(this);
        stateMachine.AddState(State.Idle, new FrogIdleState(this, stateMachine));
        stateMachine.AddState(State.Falling, new FrogFallingState(this, stateMachine));
        stateMachine.AddState(State.Trace, new FrogTraceState(this, stateMachine));
        stateMachine.AddState(State.Die, new FrogDieState(this, stateMachine));
    }

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        stateMachine.Setup(State.Falling);
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

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == layerMask)
        {
            isJump = false;
            stateMachine.Setup(State.Idle);
        }
    }
}

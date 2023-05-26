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
    [HideInInspector] public bool isDead;
    StateMachine<State, Frog> stateMachine;

    protected override void Awake()
    {
        base.Awake();

        hp = 2;

        stateMachine = new StateMachine<State, Frog>(this);
        stateMachine.AddState(State.Idle, new FrogIdleState(this, stateMachine));
        stateMachine.AddState(State.Falling, new FrogFallingState(this, stateMachine));
        stateMachine.AddState(State.Trace, new FrogTraceState(this, stateMachine));
        stateMachine.AddState(State.Die, new FrogDieState(this, stateMachine));
    }

    Coroutine fallingCool;

    IEnumerator FallingRoutine()
    {
        yield return new WaitUntil(() => isDead);
        isDead = false;
        Instantiate(gameObject, player.position * Vector2.up * 10f, transform.rotation);
    }

    private void OnEnable()
    {
        stateMachine.Setup(State.Falling);
    }

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
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

    protected override void OnCollisionEnter2D(Collision2D collision)
    {
        isJump = false;
        anim.SetBool("IsFalling", false);
        stateMachine.Setup(State.Idle);

        IHitable target = collision.gameObject.GetComponent<IHitable>();
        if (target != null)
            target.TakeDamage(damage);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, detectRange);
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRange);
    }
}

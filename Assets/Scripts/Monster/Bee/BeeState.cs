using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BeeStates
{
    public enum State { Idle, Patrol, Runaway, Return, Attack, Die, Size }

    public abstract class BeeState : StateBase<State, Bee>
    {
        protected string name { get { return owner.name; } }
        protected float attackRange { get { return owner.attackRange; } }
        protected float detectRange { get { return owner.detectRange; } }
        protected int patrolIndex { get { return owner.patrolIndex; } set { owner.patrolIndex = value; } }
        protected Vector2 dir { get { return owner.dir; } set { owner.dir = value; } }
        protected Vector3 returnPosition { get { return owner.returnPosition; } }
        protected GameObject gameObject { get { return owner.gameObject; } }
        protected FireBall fireball { get { return owner.fireball; } }
        protected SpriteRenderer render { get { return owner.render; } }
        protected Transform[] patrolPoints { get { return owner.patrolPoints; } set { owner.patrolPoints = value; } }
        protected Transform transform { get { return owner.transform; } }
        protected Transform player { get { return owner.player; } }
        protected Rigidbody2D rb { get { return owner.rb; } }
        protected Animator anim { get { return owner.anim; } }
        protected Collider2D collider { get { return owner.collider; } }

        protected BeeState(Bee owner, StateMachine<State, Bee> stateMachine) : base(owner, stateMachine) { }
    }
}
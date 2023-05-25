using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FrogStates
{
    public enum State { Idle, Falling, Trace, Die, Size }

    public abstract class FrogState : StateBase<State, Frog>
    {
        protected string name { get { return owner.name; } }
        protected float jumpPower { get { return owner.jumpPower; } }
        protected bool isJump { get { return owner.isJump; } set { owner.isJump = value; } }
        protected bool isDead { get { return owner.isDead; } set { owner.isDead = value; } }
        protected Vector2 dir { get { return owner.dir; } set { owner.dir = value; } }
        protected GameObject gameObject { get { return owner.gameObject; } }
        protected SpriteRenderer render { get { return owner.render; } }
        protected Transform transform { get { return owner.transform; } }
        protected Transform player { get { return owner.player; } }
        protected Rigidbody2D rb { get { return owner.rb; } }
        protected Animator anim { get { return owner.anim; } }
        protected Collider2D collider { get { return owner.collider; } }

        protected FrogState(Frog owner, StateMachine<State, Frog> stateMachine) : base(owner, stateMachine) { }
    }
}

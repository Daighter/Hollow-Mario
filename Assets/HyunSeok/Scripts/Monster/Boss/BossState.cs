using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BossStates
{
    public enum State { Idle, CrushAttack, NormalAttack, BombAttack, Trace, Damage, Die, Size }

    public abstract class BossState : StateBase<State, Boss>
    {
        protected int attackSeqeunce;
        protected float attackTime;

        protected string name { get { return owner.name; } }
        protected float attackRange { get { return owner.attackRange; } }
        protected float detectRange { get { return owner.detectRange; } }
        protected Vector2 dir { get { return owner.dir; } set { owner.dir = value; } }
        protected GameObject gameObject { get { return owner.gameObject; } }
        protected GameObject normal { get { return owner.normal; } }
        protected GameObject crush { get { return owner.crush; } }
        protected SpriteRenderer render { get { return owner.render; } }
        protected Transform transform { get { return owner.transform; } }
        protected Transform player { get { return owner.player; } }
        protected Rigidbody2D rb { get { return owner.rb; } }
        protected Animator anim { get { return owner.anim; } }
        protected Collider2D collider { get { return owner.collider; } }

        protected BossState(Boss owner, StateMachine<State, Boss> stateMachine) : base(owner, stateMachine) { }
    }
}

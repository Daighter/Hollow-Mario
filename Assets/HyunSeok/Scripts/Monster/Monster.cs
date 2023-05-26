using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class Monster : HpEntity
{
    [HideInInspector] public int damage;
    [HideInInspector] public Transform player;
    [HideInInspector] public Vector2 dir;
    [HideInInspector] public Rigidbody2D rb;
    [HideInInspector] public Animator anim;
    [HideInInspector] public Collider2D collider;
    [HideInInspector] public SpriteRenderer render;
    [HideInInspector] public Vector3 returnPosition;
    public float detectRange;
    public float attackRange;
    

    protected virtual void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        collider = GetComponent<Collider2D>();
        render = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
    }

    protected virtual void Attack()
    {

    }

    protected virtual void Die()
    {
        rb.gravityScale = 1.0f;
        rb.velocity = Vector2.up * 2f;
        anim.SetBool("Die", true);
        render.flipY = true;

        Destroy(gameObject, 1.5f);
    }

    protected virtual void OnCollisionEnter2D(Collision2D collision)
    {
        IHitable target = collision.gameObject.GetComponent<IHitable>();
        if (target != null)
            target.TakeDamage(damage);
    }
}

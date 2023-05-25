using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class Monster : MonoBehaviour
{
    public Transform player;
    public Vector2 dir;
    public Rigidbody2D rb;
    public Animator anim;
    public Collider2D collider;
    public SpriteRenderer render;
    public float detectRange;
    public float attackRange;
    public Vector3 returnPosition;

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
}

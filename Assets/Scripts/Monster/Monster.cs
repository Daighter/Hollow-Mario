using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class Monster : MonoBehaviour
{
    protected string name;
    protected Transform player;
    protected Vector2 dir;
    protected float moveSpeed;
    protected Rigidbody2D rb;
    protected Animator anim;
    protected Collider2D collider;
    protected SpriteRenderer render;

    protected virtual void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
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
        anim.SetTrigger("Die");
        render.flipY = true;

        Destroy(gameObject, 1.5f);
    }
}

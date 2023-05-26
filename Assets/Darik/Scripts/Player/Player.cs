using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : HpEntity
{
    [SerializeField] private int ap = 1;

    private Animator animator;

    public int Hp {  get { return hp; } }
    public int Ap { get { return ap; } }

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    private void Start()
    {
        hp = 10;
    }

    public override void TakeDamage(int damage)
    {
        base.TakeDamage(damage);
        animator.SetTrigger("OnHited");
    }
}

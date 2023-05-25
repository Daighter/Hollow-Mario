using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Skill : MonoBehaviour
{
    protected Rigidbody rb;
    protected int ap;

    protected virtual void Awake()
    {
        ap = GetComponent<Player>().Ap;
        rb = GetComponent<Rigidbody>();
    }


    protected void OnCollisionEnter(Collision collision)
    {
        IHitable target = collision.gameObject.GetComponent<IHitable>();
        if (target != null)
            target.TakeDamage(ap);
    }
}

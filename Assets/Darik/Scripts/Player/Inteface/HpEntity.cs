using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class HpEntity : MonoBehaviour, IHitable
{
    protected int hp;

    public virtual void TakeDamage(int damage)
    {
        hp -= damage;
    }
}

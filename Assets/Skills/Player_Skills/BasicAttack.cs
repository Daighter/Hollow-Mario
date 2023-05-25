using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class BasicAttack : Skill
{
    private void OnBasicAttack(InputValue value)
    {
        if (value.isPressed)
            Attack();
    }

    protected override void Attack()
    {
        Debug.Log("Attack");
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField] private GameObject basicAttackEffectPrefab;

    private void OnBasicAttack(InputValue value)
    {
        if (value.isPressed)
            Attack();
    }

    private void Attack()
    {
        Instantiate(basicAttackEffectPrefab, transform.position + Vector3.right * 1f, Quaternion.identity);
    }
}

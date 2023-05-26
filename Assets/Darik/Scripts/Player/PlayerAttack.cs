using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerAttack : MonoBehaviour
{
    private SpriteRenderer render;
    [SerializeField] private GameObject basicAttackEffectPrefab;

    private void Awake()
    {
        render = GetComponent<SpriteRenderer>();
    }

    private void OnBasicAttack(InputValue value)
    {
        if (value.isPressed)
            Attack();
    }

    private void Attack()
    {
        if (!render.flipX)
            Instantiate(basicAttackEffectPrefab, transform.position + Vector3.right * 1f, Quaternion.identity);
        else if (render.flipX)
        {
            GameObject skill = Instantiate(basicAttackEffectPrefab, transform.position + Vector3.left * 1f, Quaternion.identity);
            skill.GetComponent<SpriteRenderer>().flipX = false;
        }

    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicAttack : Skill
{
    [SerializeField] int damage = 2;

    private void Awake()
    {
        runTime = 0.1f;
    }
}

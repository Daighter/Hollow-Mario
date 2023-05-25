using FrogStates;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Frog : Monster
{
    [SerializeField] private string name;

    StateMachine<State, Frog> stateMachine;

    protected override void Awake()
    {
        base.Awake();

        stateMachine = new StateMachine<State, Frog>(this);

    }
}

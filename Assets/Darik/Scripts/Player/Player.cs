using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : HpEntity
{
    [SerializeField] private int ap = 1;

    public int Hp {  get { return hp; } }
    public int Ap { get { return ap; } }

    private void Start()
    {
        hp = 10;
    }
}

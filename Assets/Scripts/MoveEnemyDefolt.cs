using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveEnemyDefolt : MoveEnemy////INHERITANCE
{
    [SerializeField] protected private float speedD { get; private set; } = 0.75f;// ENCAPSULATION

    protected private void Awake()// POLYMORPHISM
    {
        HpEnemy();
        base.SetHP();
    }
    protected private void FixedUpdate()// POLYMORPHISM
    {
        MoveEnemyLeft();
        base.TransformPos();
    }

    protected override void MoveEnemyLeft()// ABSTRACTION
    {
        speed = Random.Range(speedD/ 2, speedD);
    }

    protected override void HpEnemy()// ABSTRACTION
    {
        amountToBeDie = 2;
    }
}

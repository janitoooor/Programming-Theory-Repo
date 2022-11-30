using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveEnemyDefolt : MoveEnemy
{
    [SerializeField] protected private float speedD { get; private set; } = 0.75f;

    protected private void Awake()
    {
        HpEnemy();
        base.SetHP();
    }
    protected private void FixedUpdate()
    {
        MoveEnemyLeft();
        base.TransformPos();
    }

    protected override void MoveEnemyLeft()
    {
        speed = Random.Range(speedD/ 2, speedD);
    }

    protected override void HpEnemy()
    {
        amountToBeDie = 2;
    }
}

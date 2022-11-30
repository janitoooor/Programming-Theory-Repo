using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpChick : MovePowerUp//INHERITANCE
{
    [SerializeField] protected private float chickSpeed = 2.5f;
    protected override void MovePowerUpLeft()
    {
        speed = chickSpeed;
    }

    protected private void FixedUpdate()// POLYMORPHISM
    {
        MovePowerUpLeft();
        base.MoveLeft();
    }
}

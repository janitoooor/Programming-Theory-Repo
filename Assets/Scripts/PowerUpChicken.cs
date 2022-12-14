using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpChicken : MovePowerUp//INHERITANCE
{
    [SerializeField] protected private float chickenSpeed = 3.5f;
    protected override void MovePowerUpLeft()// ABSTRACTION
    {
        speed = chickenSpeed;
    }

    protected private void FixedUpdate()// POLYMORPHISM// ABSTRACTION
    {
        MovePowerUpLeft();
        base.MoveLeft();
    }
}

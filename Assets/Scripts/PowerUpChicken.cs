using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpChicken : MovePowerUp
{
    [SerializeField] protected private float chickenSpeed = 3.5f;
    protected override void MovePowerUpLeft()
    {
        speed = chickenSpeed;
    }

    protected private void FixedUpdate()
    {
        MovePowerUpLeft();
        base.MoveLeft();
    }
}

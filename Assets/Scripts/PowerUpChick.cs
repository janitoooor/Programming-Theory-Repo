using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpChick : MovePowerUp
{
    [SerializeField] protected private float chickSpeed = 2.5f;
    protected override void MovePowerUpLeft()
    {
        speed = chickSpeed;
    }

    protected private void FixedUpdate()
    {
        MovePowerUpLeft();
        base.MoveLeft();
    }
}

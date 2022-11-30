using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveFastEnemy : MoveEnemy
{
    protected float speedF = 1f;
    protected private void Awake()
    {
        HpEnemy();
        base.SetHP();
        StartCoroutine(PlayFire());
    }
    protected private void FixedUpdate()
    {
        MoveEnemyLeft();
        base.TransformPos();
    }
    protected override void MoveEnemyLeft()
    {
        speed = Random.Range(speedF / 2, speedF);
        timePlay = 1.5f;
    }

    protected override void HpEnemy() 
    {
        amountToBeDie = 1;
    }

    IEnumerator PlayFire()
    {
        yield return new WaitForSeconds(timeWait);
        if (isDie != true)
        {
            animator.SetBool("Walk_Forward", false);
            animator.SetBool("FireShow", true);
            particles.Play();
            effectSound.Play();
            StartCoroutine(StopFire());
        }
    }

    IEnumerator StopFire()
    {
        yield return new WaitForSeconds(timePlay);
        if (isDie != true)
        {
            animator.SetBool("FireShow", false);
            animator.SetBool("Walk_Forward", true);
            particles.Stop();
            effectSound.Stop();
            StartCoroutine(PlayFire());
        }
    }
}

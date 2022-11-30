using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveEnemyBig : MoveEnemy
{
    protected float speedB = 0.45f;

    protected private void Awake()
    {
        HpEnemy();
        base.SetHP();
        StartCoroutine(PlayJump());
    }
    protected private void FixedUpdate()
    {
        MoveEnemyLeft();
        base.TransformPos();
    }

    protected override void MoveEnemyLeft()
    {
        speed = Random.Range(speedB / 2, speedB);
    }

    protected override void HpEnemy()
    {
        amountToBeDie = 5;
    }

    IEnumerator PlayJump()
    {
        yield return new WaitForSeconds(timeWait);
        if (isDie != true)
        {
            animator.SetBool("Walk_Forward", false);
            animator.SetBool("JumpOn", true);
            particles.Stop();
            StartCoroutine(StopJump());
        }
    }

    IEnumerator StopJump()
    {
        yield return new WaitForSeconds(timePlay);
        if (isDie != true)
        {
            animator.SetBool("JumpOn", false);
            animator.SetBool("Walk_Forward", true);
            particles.Play();
            effectSound.Play();
            StartCoroutine(PlayJump());
        }
    }
}

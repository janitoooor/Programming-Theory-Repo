using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class EnemyHP : MonoBehaviour
{
    [SerializeField] protected private int amountToBeDie;
    [SerializeField] protected Slider sliderHP;
    [SerializeField] protected int currentAmount { get; private set; } = 0;
    [SerializeField] protected Animator animator;
    [SerializeField] private ParticleSystem dieParitcles;
    [SerializeField] private ParticleSystem explosionParitcles;
    [SerializeField] private AudioSource explosionSound;
    [SerializeField] private AudioSource dieSound;
    [SerializeField] protected bool isDie { get; private set; }
    [SerializeField] protected bool isAttack { get; private set; }

    public virtual void KillEnemy(int amount)
    {
        currentAmount += amount;
        sliderHP.fillRect.gameObject.SetActive(true);
        sliderHP.value = currentAmount;

        if(currentAmount >= amountToBeDie)
        {
            if (isDie != true)
            {
                DieEnemy();
            }
        }
    }

    public virtual void AttackAndDie()
    {
        AttackAnimator();
        StartCoroutine(AttackDoors());
    }

    IEnumerator AttackDoors()
    {
        yield return new WaitForSeconds(1);
        DieExplosion();
    }

    public virtual void GameOver()
    {
        StartCoroutine(GameOverBool());
    }

    IEnumerator GameOverBool()
    {
        yield return new WaitForSeconds(2);
        MainUI.gameOver = true;
    }

    public virtual void DieEnemy()
    {
        sliderHP.value = sliderHP.maxValue;
        sliderHP.fillRect.gameObject.SetActive(true);
        DieAnimator();
        Destroy(gameObject, 1.8f);
        dieParitcles.Play();
        dieSound.Play();
        isDie = true;
    }

    public virtual void DieExplosion()
    {
        DieEnemy();
        explosionParitcles.Play();
        explosionSound.Play();
    }

    public virtual void DieAnimator()
    {
        animator.SetBool("Walk_Forward", false);
        animator.SetBool("JumpOn", false);
        animator.SetBool("FireShow", false);
        animator.SetBool("Attack", false);
        animator.SetBool("Die", true);
    }

    public virtual void AttackAnimator()
    {
        animator.SetBool("Walk_Forward", false);
        animator.SetBool("JumpOn", false);
        animator.SetBool("FireShow", false);
        animator.SetBool("Attack", true);
        isAttack = true;
    }

    public virtual void SetHP()
    {
        sliderHP.maxValue = amountToBeDie;
        sliderHP.value = 0;
        sliderHP.fillRect.gameObject.SetActive(false);
    }

    protected abstract void HpEnemy();
}

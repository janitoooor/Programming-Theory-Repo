using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class EnemyHP : MonoBehaviour// INHERITANCE
{
    [SerializeField] protected private int amountToBeDie;
    [SerializeField] protected Slider sliderHP;
    [SerializeField] protected int currentAmount { get; private set; } = 0;// ENCAPSULATION
    [SerializeField] protected Animator animator;
    [SerializeField] private ParticleSystem dieParitcles;
    [SerializeField] private ParticleSystem explosionParitcles;
    [SerializeField] private AudioSource explosionSound;
    [SerializeField] private AudioSource dieSound;
    [SerializeField] protected bool isDie { get; private set; }// ENCAPSULATION
    [SerializeField] protected bool isAttack { get; private set; }// ENCAPSULATION

    public virtual void KillEnemy(int amount)// ABSTRACTION
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

    public virtual void AttackAndDie()// POLYMORPHISM// ABSTRACTION
    {
        AttackAnimator();
        StartCoroutine(AttackDoors());
    }

    IEnumerator AttackDoors()// ABSTRACTION
    {
        yield return new WaitForSeconds(1);
        DieExplosion();
    }

    public virtual void GameOver()// POLYMORPHISM// ABSTRACTION
    {
        StartCoroutine(GameOverBool());
    }

    IEnumerator GameOverBool()// POLYMORPHISM// ABSTRACTION
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

    public virtual void DieExplosion()// ABSTRACTION
    {
        DieEnemy();
        explosionParitcles.Play();
        explosionSound.Play();
    }

    public virtual void DieAnimator()// ABSTRACTION
    {
        animator.SetBool("Walk_Forward", false);
        animator.SetBool("JumpOn", false);
        animator.SetBool("FireShow", false);
        animator.SetBool("Attack", false);
        animator.SetBool("Die", true);
    }

    public virtual void AttackAnimator()// ABSTRACTION
    {
        animator.SetBool("Walk_Forward", false);
        animator.SetBool("JumpOn", false);
        animator.SetBool("FireShow", false);
        animator.SetBool("Attack", true);
        isAttack = true;
    }

    public virtual void SetHP()// ABSTRACTION
    {
        sliderHP.maxValue = amountToBeDie;
        sliderHP.value = 0;
        sliderHP.fillRect.gameObject.SetActive(false);
    }

    protected abstract void HpEnemy();
}

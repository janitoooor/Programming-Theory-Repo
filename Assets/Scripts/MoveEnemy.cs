using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class MoveEnemy : EnemyHP//// INHERITANCE
{
    

    [SerializeField] protected private AudioSource effectSound;
    [SerializeField] protected private ParticleSystem particles;

    protected private float maxTimeWait = 4;
    [SerializeField] protected private float timeWait { get; private set; }
    protected private float timePlay = 0.8f;
    protected private float speed;

    [SerializeField] static float boundX { get; } = -7.5f;// ENCAPSULATION
    [SerializeField] static float boundZ { get; } = 5.99f;// ENCAPSULATION
    [SerializeField] static float spawnZ { get; } = 6.17f;// ENCAPSULATION
    [SerializeField] static float spawnTopZ { get; } = 8.35f;// ENCAPSULATION
    [SerializeField] static float topBoundZ { get; } = 7.99f;// ENCAPSULATION
    [SerializeField] static float midBoundZ { get; } = 6.01f;// ENCAPSULATION
    [SerializeField] static float midBoundZz { get; } = 7.01f;// ENCAPSULATION
    [SerializeField] static float midBoundZzz { get; } = 6.99f;// ENCAPSULATION
    [SerializeField] static float spawnTopZz { get; } = 7.25f;// ENCAPSULATION

    void Start()// ABSTRACTION
    {
        timeWait = Random.Range(maxTimeWait / 2, maxTimeWait);
    }

    protected override void HpEnemy()
    {

    }

    public virtual void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Door"))
        {
            Destroy(other.gameObject,1.2f);
            base.AttackAndDie();
        }
        if(other.gameObject.CompareTag("Player"))
        {
            base.AttackAndDie();
            base.GameOver();
            PlayerController.IsDie = true;
        }
    }

    public virtual void TransformPos()
    {
        if (!isDie)
        {
            if (!isAttack)
            {
                transform.Translate(Vector3.left * speed * Time.deltaTime);
            }
        }

        if (transform.position.x < boundX)
        {
            PlayerController.IsDie = true;
            MainUI.gameOver = true;
            Destroy(gameObject);
        }

        if (transform.position.z > boundZ && transform.position.z < midBoundZ)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, spawnZ);
        }
        
        if (transform.position.z > topBoundZ)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, spawnTopZ);
        }

        if (transform.position.z > midBoundZzz && transform.position.z < midBoundZz)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, spawnTopZz);
        }
    }

    protected abstract void MoveEnemyLeft();
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class MovePowerUp : MonoBehaviour//INHERITANCE
{
    [SerializeField] protected private float speed;
    [SerializeField] protected private float boundX { get; private set; } = -7.5f;// ENCAPSULATION
    [SerializeField] protected AudioSource soundDie;
    [SerializeField] protected ParticleSystem particleDie;

    public virtual void MoveLeft()// ABSTRACTION
    {
        transform.Translate(Vector3.left * speed * Time.deltaTime);
        if (transform.position.x < boundX)
        {
            Destroy(gameObject);
        }
    }

    public virtual void OnTriggerEnter(Collider other)// ABSTRACTION
    {
        if (other.gameObject.CompareTag("Door"))
        {
            PlayInCollision();
        }
        else if (other.gameObject.CompareTag("Player"))// ABSTRACTION
        {
            PlayInCollision();
        }
    }

    public virtual void PlayInCollision()// ABSTRACTION
    {
        soundDie.Play();
        particleDie.Play();
        Destroy(gameObject, 0.1f);
    }

    protected abstract void MovePowerUpLeft();
}

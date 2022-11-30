using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class MovePowerUp : MonoBehaviour
{
    [SerializeField] protected private float speed;
    [SerializeField] protected private float boundX { get; private set; } = -7.5f;
    [SerializeField] protected AudioSource soundDie;
    [SerializeField] protected ParticleSystem particleDie;

    public virtual void MoveLeft()
    {
        transform.Translate(Vector3.left * speed * Time.deltaTime);
        if (transform.position.x < boundX)
        {
            Destroy(gameObject);
        }
    }

    public virtual void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Door"))
        {
            soundDie.Play();
            particleDie.Play();
            Destroy(gameObject,0.1f);
        }
        else if (other.gameObject.CompareTag("Player"))
        {
            soundDie.Play();
            particleDie.Play();
            Destroy(gameObject, 0.1f);
        }
    }

    protected abstract void MovePowerUpLeft();
}

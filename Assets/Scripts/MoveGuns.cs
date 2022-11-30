using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveGuns : MonoBehaviour
{
    [SerializeField] protected private float speed { get; private set; } = 6;

    [SerializeField] protected private float timeToDestroy { get; private set; } = 0.04f;
    [SerializeField] protected private float boundX { get; private set; } = 5.2f;
    [SerializeField] protected private float rotateSpeed { get; private set; } = 250;

    [SerializeField] private AudioSource soundHit;

    // Update is called once per frame
    protected private void Update()
    {
        TransformPos();
    }

    protected private void TransformPos()
    {
        transform.Translate(Vector3.up * -speed * Time.deltaTime);
        transform.Rotate(Vector3.up * rotateSpeed * Time.deltaTime);

        if (transform.position.x > boundX)
        {
            Destroy(gameObject);
        }
    }

    protected private void OnTriggerEnter(Collider other) 
    {
        if(other.gameObject.CompareTag("Enemy"))
        {
            soundHit.Play();
            Destroy(gameObject, timeToDestroy);
            other.GetComponent<EnemyHP>().KillEnemy(1);
        }
    }
}

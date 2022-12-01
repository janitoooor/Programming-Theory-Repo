using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChkenMove : MonoBehaviour
{
    [SerializeField] protected private float walkSpeed { get; private set; } = 1;
    [SerializeField] protected private float timeToEat { get; private set; } = 4;

    [SerializeField] protected private float timeToWait { get; private set; } = 3;

    [SerializeField] protected private Transform startPoint;

    [SerializeField] protected private ParticleSystem particles;

    [SerializeField] protected private AudioSource soundChick;
    [SerializeField] protected private Animator chickenAnimator { get; private set; }

    private protected void Awake()
    {
        StartCoroutine(PlayIntro());
    }

    IEnumerator PlayIntro()
    {
        chickenAnimator = GetComponent<Animator>();

        Vector3 startPos = transform.position;
        Vector3 endPos = startPoint.position;

        float journeyLength = Vector3.Distance(startPos, endPos);
        float startTime = Time.deltaTime;

        float distanceCovered = (Time.time - startTime) * walkSpeed;
        float fractionJourney = distanceCovered / journeyLength;

        chickenAnimator.SetBool("Run", false);
        chickenAnimator.SetBool("Walk", true);

        while (fractionJourney < 1)
        {
            distanceCovered = (Time.time - startTime) * walkSpeed;
            fractionJourney = distanceCovered / journeyLength;
            transform.position = Vector3.Lerp(startPos, endPos, fractionJourney);
            yield return null;
        }

        chickenAnimator.SetBool("Walk", false);
        chickenAnimator.SetBool("Turn_Head", true);
        StartCoroutine(EatNow());
    }

    IEnumerator HeadUp()
    {
        float timeEat = Random.Range(timeToEat--, timeToEat++);

        yield return new WaitForSeconds(timeEat);
        chickenAnimator.SetBool("Eat", false);
        chickenAnimator.SetBool("Turn_Head", true);
        StartCoroutine(EatNow());
    }

    IEnumerator EatNow()
    {
        float timeWait = Random.Range(timeToWait--, timeToWait++);

        yield return new WaitForSeconds(timeWait);
        chickenAnimator.SetBool("Turn_Head", false);
        chickenAnimator.SetBool("Eat", true);
        StartCoroutine(HeadUp());
    }

    private protected void OnMouseDown()
    {
        Instantiate(particles, transform.position, particles.transform.rotation);
        soundChick.Play();
        Destroy(gameObject);
    }
}

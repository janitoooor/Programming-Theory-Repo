using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChkenMove : MonoBehaviour
{
    [SerializeField] float walkSpeed;
    private float timeToEat = 4;
    private float timeToWait = 3;
    [SerializeField] Transform startPoint;
    private Animator chickenAnimator;

    void Start()
    {
        chickenAnimator = GetComponent<Animator>();
        StartCoroutine(PlayIntro());
    }

    IEnumerator PlayIntro()
    {
        Vector3 startPos = transform.position;
        Vector3 endPos = startPoint.position;

        float journeyLength = Vector3.Distance(startPos, endPos);
        float startTime = Time.deltaTime;

        float distanceCovered = (Time.time - startTime) * walkSpeed;
        float fractionJourney = distanceCovered / journeyLength;

        chickenAnimator.SetBool("Walk", true);

        while (fractionJourney < 1)
        {
            distanceCovered = (Time.time - startTime) * walkSpeed;
            fractionJourney = distanceCovered / journeyLength;
            transform.position = Vector3.Lerp(startPos, endPos, fractionJourney);
            yield return null;
        }

        chickenAnimator.SetBool("Walk", false);
        chickenAnimator.SetBool("Eat", true);
        StartCoroutine(HeadUp());
    }

    IEnumerator HeadUp()
    {
        yield return new WaitForSeconds(timeToEat);
        chickenAnimator.SetBool("Eat", false);
        chickenAnimator.SetBool("Turn_Head", true);
        StartCoroutine(EatNow());
    }

    IEnumerator EatNow()
    {
        yield return new WaitForSeconds(timeToWait);
        chickenAnimator.SetBool("Turn_Head", false);
        chickenAnimator.SetBool("Eat", true);
        StartCoroutine(HeadUp());
    }    

}

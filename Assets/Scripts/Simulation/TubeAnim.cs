using System.Collections;
using UnityEngine;

public class TubeAnim : MonoBehaviour
{
    public Animator animator;
    public Transform targetPivot1;
    public Transform targetPivot2;
    public GameObject lastSlide;
    private float moveSpeed = 8f; // 이동 속도

    private bool hasPlayedAnimation = false;

    private void Awake()
    {
        PlayAnimation();
    }

    private void Update()
    {
        if (hasPlayedAnimation)
        {
            StartCoroutine(MoveToTargetPivot1AfterDelay());
        }
    }

    private void PlayAnimation()
    {
        if (animator != null && animator.runtimeAnimatorController != null)
        {
            animator.SetTrigger("locate");
            hasPlayedAnimation = true;
        }
    }

    private IEnumerator MoveToTargetPivot1AfterDelay()
    {
        yield return new WaitForSeconds(1f); // 1초 대기

        StartCoroutine(MoveObjectToPivot(gameObject, targetPivot1));
    }

    private IEnumerator MoveObjectToPivot(GameObject movingObject, Transform targetPivot)
    {
        Vector3 startPosition = movingObject.transform.position;
        Quaternion startRotation = movingObject.transform.rotation;
        float startTime = Time.time;
        float journeyLength = Vector3.Distance(startPosition, targetPivot.position);

        while (movingObject.transform.position != targetPivot.position)
        {
            float distanceCovered = (Time.time - startTime) * moveSpeed;
            float fractionOfJourney = distanceCovered / journeyLength;

            movingObject.transform.position = Vector3.Lerp(startPosition, targetPivot.position, fractionOfJourney);
            movingObject.transform.rotation = Quaternion.Slerp(startRotation, targetPivot.rotation, fractionOfJourney);

            yield return null;
        }

        if (targetPivot == targetPivot1)
        {
            yield return new WaitForSeconds(1f); 

            StartCoroutine(MoveObjectToPivot(movingObject, targetPivot2));
        }
        else if (targetPivot == targetPivot2)
        {
            yield return new WaitForSeconds(2f); // 2초 대기

            if (lastSlide != null)
            {
                lastSlide.SetActive(true);
            }
        }
    }
}

using System.Collections;
using UnityEngine;

public class SyringeMovement : MonoBehaviour
{
    public GameObject syringeObject;
    public Transform syringePivot1;
    public Transform syringePivot2;
    public Transform syringePivot3;
    public Transform syringePivot4;
    public GameObject nextSlide;
    public GameObject tubeObject;
    public Transform tubePivot;

    public GameObject slide9;
    public GameObject triggerObject;
    public float moveSpeed = 0.18f;
    public Animator animator;

    private bool hasMoved = false;
    private bool hasMovedToPivot3 = false;

    private void Start()
    {
        if (!hasMoved)
        {
            StartCoroutine(StartMovementSequence());
        }
    }

    private void Update()
    {
        if(syringeObject.transform.position == syringePivot4.position)
        {
            nextSlide.SetActive(true);
        }
        // Check if triggerObject is active and move to syringePivot3 if not moved yet
        if (triggerObject != null && triggerObject.activeSelf && !hasMovedToPivot3)
        {
            hasMovedToPivot3 = true;
            StartCoroutine(MoveObjectToPivot(syringeObject, syringePivot3));

            // Trigger push action animation
            PlayPushAction();

            // Wait for 2 seconds and move to syringePivot4
            StartCoroutine(MoveToSyringePivot4AfterDelay(3f));
        }
    }

    private IEnumerator StartMovementSequence()
    {
        yield return StartCoroutine(MoveObjectToPivot(syringeObject, syringePivot1));

        PlayAnimation();

        yield return new WaitForSeconds(2);
        ActivateSlide9();

        StartCoroutine(MoveObjectToPivot(syringeObject, syringePivot2));
        tubeObject.SetActive(true);

        yield return StartCoroutine(MoveObjectToPivot(tubeObject, tubePivot));
        hasMoved = true;
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
    }

    private void PlayAnimation()
    {
        if (animator != null && animator.runtimeAnimatorController != null)
        {
            animator.SetTrigger("Pull");
        }
    }

    private void ActivateSlide9()
    {
        slide9.SetActive(true);
    }

    private void PlayPushAction()
    {
        if (animator != null && animator.runtimeAnimatorController != null)
        {
            animator.SetTrigger("Push");
        }
    }

    private IEnumerator MoveToSyringePivot4AfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);

        StartCoroutine(MoveObjectToPivot(syringeObject, syringePivot4));
    }
}

using System.Collections;
using UnityEngine;

public class SyringeMove2 : MonoBehaviour
{
    public GameObject syringeObject;
    public Transform syringePivot2;
    public float moveSpeed = 0.5f;
    public Animator animator;  // Public Animator

    public void StartMovingToPivot2()
    {
        StartCoroutine(MoveObjectToPivot(syringeObject, syringePivot2));
    }

    IEnumerator MoveObjectToPivot(GameObject movingObject, Transform targetPivot)
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

        PlayAnimation();
    }

    void PlayAnimation()
    {
        if (animator != null && animator.runtimeAnimatorController != null)
        {
            animator.SetTrigger("Push"); 
        }
    }
}

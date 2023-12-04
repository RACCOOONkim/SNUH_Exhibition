using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class MoveAndRotateToObject : MonoBehaviour
{
    public GameObject catheter; // object1
    public GameObject catheterPivot; // what object1 will move and rotate
    public GameObject bandage; // object 3
    public GameObject bandagePivot; // what object3 will move and rotate
    public GameObject slide8; // Image UI object to be activated

    public float moveSpeed = 1.0f; // speed
    public float rotateSpeed = 1.0f; // rotation speed

    private bool isMoving = false;
    private bool slide8Activated = false; // Flag to track if slide8 has been activated

    private void Update()
    {
        // Start moving and rotating when object1 is active
        if (catheter.activeSelf && !isMoving)
        {
            StartCoroutine(MoveAndRotateToTarget());
        }
    }

    IEnumerator MoveAndRotateToTarget()
    {
        isMoving = true;

        while (Vector3.Distance(transform.position, catheterPivot.transform.position) > 0.01f || Quaternion.Angle(transform.localRotation, catheterPivot.transform.localRotation) > 0.01f)
        {
            // Move and rotate the position of object 1
            transform.position = Vector3.Lerp(transform.position, catheterPivot.transform.position, moveSpeed * Time.deltaTime);
            transform.localRotation = Quaternion.Slerp(transform.localRotation, catheterPivot.transform.localRotation, rotateSpeed * Time.deltaTime);
            yield return null;
        }

        transform.position = catheterPivot.transform.position;
        transform.localRotation = catheterPivot.transform.localRotation;

        bandage.SetActive(true);

        while (Vector3.Distance(bandage.transform.position, bandagePivot.transform.position) > 0.01f || Quaternion.Angle(bandage.transform.localRotation, bandagePivot.transform.localRotation) > 0.01f)
        {
            // Move and rotate the position of object 3
            bandage.transform.position = Vector3.Lerp(bandage.transform.position, bandagePivot.transform.position, moveSpeed * Time.deltaTime);
            bandage.transform.localRotation = Quaternion.Slerp(bandage.transform.localRotation, bandagePivot.transform.localRotation, rotateSpeed * Time.deltaTime);
            yield return null;
        }

        bandage.transform.position = bandagePivot.transform.position;
        bandage.transform.localRotation = bandagePivot.transform.localRotation;

        if (!slide8Activated)
        {
            yield return new WaitForSeconds(1.5f); // Wait for 1.5 seconds

            slide8.SetActive(true); // Enable Image UI
            slide8Activated = true; // Mark slide8 as activated
        }

        isMoving = false;
    }
}

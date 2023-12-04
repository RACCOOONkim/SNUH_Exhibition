using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SyringeAndCylinderMove : MonoBehaviour
{
    public GameObject syringeObject; // 주사기 오브젝트에 대한 참조
    public GameObject syringePivot2; // 주사기 두 번째 위치 피벗에 대한 참조
    public GameObject syringePivot3; // 주사기 세 번째 위치 피벗에 대한 참조

    public GameObject cylinderObject; // 실린더 오브젝트에 대한 참조
    public GameObject cylinderPivot1; // 실린더 첫 번째 위치 피벗에 대한 참조
    public GameObject cylinderPivot2; // 실린더 두 번째 위치 피벗에 대한 참조

    public GameObject slide9; // 슬라이드 9 오브젝트에 대한 참조
    public GameObject slide10; // 슬라이드 10 오브젝트에 대한 참조
    private bool slide10Activated = false; // 슬라이드 10이 활성화되었는지 여부를 나타내는 변수

    public List<GameObject> objectsToDisable; // 비활성화할 오브젝트 목록
    public List<GameObject> objectsToable; // 활성화할 오브젝트 목록

    public float moveSpeed = 0.5f; // 이동 속도
    public float rotateSpeed = 0.6f; // 회전 속도

    public float fadeInDuration = 2.0f; // 페이드 인 지속 시간
    public float fadeOutDuration = 5.0f; // 페이드 아웃 지속 시간

    private bool hasMovedToSecondPosition = false; // 두 번째 위치로 이동했는지 여부를 나타내는 변수
    private bool hasMovedToThirdPosition = false; // 세 번째 위치로 이동했는지 여부를 나타내는 변수
    private bool isMoving = false; // 이동 중인지 여부를 나타내는 변수
    private GameObject imageUI; // 이미지 오브젝트에 대한 참조

    private void Awake()
    {
        imageUI = gameObject;
    }

    private void OnEnable()
    {
        StartCoroutine(FadeIn());
    }

    private void OnDisable()
    {
        if (slide9 != null && slide9.activeSelf)
        {
            StartCoroutine(FadeOut());
        }
    }

    private void Update()
    {
        if (!hasMovedToSecondPosition && !isMoving)
        {
            isMoving = true;
            StartCoroutine(MoveAndRotate(syringeObject, syringePivot2));
            cylinderObject.SetActive(true);
            StartCoroutine(MoveAndRotate(cylinderObject, cylinderPivot1));
            DisableObjects();
            AbleObject();
        }
        else if (hasMovedToSecondPosition && !hasMovedToThirdPosition && !isMoving)
        {
            StartCoroutine(DelayAndMoveToThirdPosition());
        }
    }

    IEnumerator DelayAndMoveToThirdPosition()
    {
        yield return new WaitForSeconds(3.0f); // 3초 대기
        isMoving = true;
        StartCoroutine(MoveAndRotate(syringeObject, syringePivot3));
        StartCoroutine(MoveAndRotate(cylinderObject, cylinderPivot2));
        DisableObjects();
        AbleObject();
        if (!slide10Activated) // 슬라이드 10이 활성화되지 않았을 경우에만 실행
        {
            StartCoroutine(FadeOutSlideAndActivateNext());
        }
    }

    IEnumerator FadeIn()
    {
        float elapsedTime = 0f;
        Color originalColor = imageUI.GetComponent<Image>().color;
        while (elapsedTime < fadeInDuration)
        {
            float alpha = elapsedTime / fadeInDuration;
            originalColor.a = alpha;
            imageUI.GetComponent<Image>().color = originalColor;
            elapsedTime += Time.deltaTime;
            yield return null;
        }
        originalColor.a = 1.0f;
        imageUI.GetComponent<Image>().color = originalColor;
    }

    IEnumerator FadeOut()
    {
        float elapsedTime = 0f;
        Color originalColor = imageUI.GetComponent<Image>().color;
        while (elapsedTime < fadeOutDuration)
        {
            float alpha = 1.0f - (elapsedTime / fadeOutDuration);
            originalColor.a = alpha;
            imageUI.GetComponent<Image>().color = originalColor;
            elapsedTime += Time.deltaTime;
            yield return null;
        }
        originalColor.a = 0.0f;
        imageUI.GetComponent<Image>().color = originalColor;
    }

    IEnumerator MoveAndRotate(GameObject movingObject, GameObject targetPivot)
    {
        Vector3 startPosition = movingObject.transform.position;
        Quaternion startRotation = movingObject.transform.rotation;
        float startTime = Time.time;
        float journeyLength = Vector3.Distance(startPosition, targetPivot.transform.position);

        while (movingObject.transform.position != targetPivot.transform.position)
        {
            float distanceCovered = (Time.time - startTime) * moveSpeed;
            float fractionOfJourney = distanceCovered / journeyLength;

            movingObject.transform.position = Vector3.Lerp(startPosition, targetPivot.transform.position, fractionOfJourney);
            movingObject.transform.rotation = Quaternion.Slerp(startRotation, targetPivot.transform.rotation, fractionOfJourney);

            yield return null;
        }

        if (targetPivot == syringePivot2)
        {
            hasMovedToSecondPosition = true;
        }
        else if (targetPivot == syringePivot3)
        {
            hasMovedToThirdPosition = true;
        }

        isMoving = false;
    }

    void DisableObjects()
    {
        foreach (GameObject obj in objectsToDisable)
        {
            obj.SetActive(false);
        }
    }
    void AbleObject()
    {
        foreach (GameObject obj2 in objectsToable)
        {
            obj2.SetActive(true);
        }
    }

    IEnumerator FadeOutSlideAndActivateNext()
    {
        // slide 9 fade out
        float elapsedTime = 0f;
        Color originalColor = slide9.GetComponent<Image>().color;

        while (elapsedTime < fadeOutDuration)
        {
            float alpha = 1.0f - (elapsedTime / fadeOutDuration);
            originalColor.a = alpha;
            slide9.GetComponent<Image>().color = originalColor;
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        slide9.SetActive(false);
        // enable slide 10
        slide10Activated = true; // 슬라이드 10 활성화 상태로 변경
        slide10.SetActive(true);
    }
}

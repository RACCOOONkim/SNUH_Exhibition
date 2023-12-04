using UnityEngine;
using UnityEngine.UI;

public class Slide10 : MonoBehaviour
{
    public float fadeInDuration = 3.0f; // 3초 동안 페이드 인
    private Image imageUI; // 이미지 오브젝트에 대한 참조
    private Color targetColor; // 페이드 인이 완료된 색상
    private bool isFadingIn = true; // 페이드 인 중인지 여부
    private bool fadeInComplete = false; // 페이드 인 완료 여부

    public GameObject syringeObject; // 주사기 오브젝트
    public Transform syringePivot; // 주사기를 이동시킬 위치
    public GameObject cylinderObject; // 실린더 오브젝트
    public Transform cylinderPivot1; // 실린더 첫 번째 위치
    public Transform cylinderPivot2; // 실린더 두 번째 위치

    public float moveSpeed = 1.0f; // 이동 속도
    public float rotateSpeed = 1.0f; // 회전 속도

    private Quaternion initialSyringeRotation; // 주사기 초기 회전 값
    private Quaternion initialCylinderRotation; // 실린더 초기 회전 값

    private bool movedToPivot1 = false; // 첫 번째 위치로 이동했는지 여부
    private bool movedToPivot2 = false; // 두 번째 위치로 이동했는지 여부

    private void Awake()
    {
        imageUI = GetComponent<Image>();
        targetColor = imageUI.color;
        targetColor.a = 1.0f; // 페이드 인 완료 시 투명도를 1로 설정
        imageUI.color = new Color(imageUI.color.r, imageUI.color.g, imageUI.color.b, 0.0f); // 투명한 상태로 초기화

        initialSyringeRotation = syringeObject.transform.rotation;
        initialCylinderRotation = cylinderObject.transform.rotation;
    }

    private void Update()
    {
        // 페이드 인 중인 경우
        if (isFadingIn)
        {
            float elapsedTime = Time.time; // 현재 시간
            float alpha = Mathf.Clamp01(elapsedTime / fadeInDuration); // 경과 시간에 따른 투명도 계산
            imageUI.color = new Color(targetColor.r, targetColor.g, targetColor.b, alpha);

            // 페이드 인이 완료된 경우
            if (alpha >= 1.0f)
            {
                isFadingIn = false; // 페이드 인 종료
                fadeInComplete = true; // 페이드 인 완료 상태로 설정
            }
        }

        // 페이드 인이 완료된 후 주사기와 실린더를 이동 및 회전시킵니다.
        if (fadeInComplete)
        {
            MoveAndRotateObjects();
        }
    }

    private void MoveAndRotateObjects()
    {
        // 주사기 이동
        syringeObject.transform.position = Vector3.MoveTowards(syringeObject.transform.position, syringePivot.position, Time.deltaTime * moveSpeed);

        // 주사기 회전
        float step = rotateSpeed * Time.deltaTime;
        syringeObject.transform.rotation = Quaternion.RotateTowards(syringeObject.transform.rotation, syringePivot.rotation, step);

        // 첫 번째 위치로 이동
        if (!movedToPivot1)
        {
            cylinderObject.transform.position = Vector3.MoveTowards(cylinderObject.transform.position, cylinderPivot1.position, Time.deltaTime * moveSpeed);
            cylinderObject.transform.rotation = Quaternion.RotateTowards(cylinderObject.transform.rotation, initialCylinderRotation, step);

            if (cylinderObject.transform.position == cylinderPivot1.position)
            {
                movedToPivot1 = true;
            }
        }
        // 두 번째 위치로 이동
        else if (!movedToPivot2)
        {
            cylinderObject.transform.position = Vector3.MoveTowards(cylinderObject.transform.position, cylinderPivot2.position, Time.deltaTime * moveSpeed);
            cylinderObject.transform.rotation = Quaternion.RotateTowards(cylinderObject.transform.rotation, cylinderPivot2.rotation, step);
            // x 회전 값을 고정하도록 조정
            Vector3 eulerRotation = cylinderObject.transform.rotation.eulerAngles;
            eulerRotation.x = 0;
            cylinderObject.transform.rotation = Quaternion.Euler(eulerRotation);

            if (cylinderObject.transform.position == cylinderPivot2.position)
            {
                movedToPivot2 = true;
            }
        }
    }
}


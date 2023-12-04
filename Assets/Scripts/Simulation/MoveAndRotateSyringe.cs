using System.Collections;
using UnityEngine;

public class MoveAndRotateSyringe : MonoBehaviour
{
    public GameObject syringeObject;
    public GameObject syringePivot;
    public GameObject slide8;
    public GameObject slide9;
    public string animationName = "YourAnimationName";
    public float rotateSpeed = 0.5f;

    private bool isMoving = false;
    private bool hasMoved = false; // 이동 여부를 확인하기 위한 변수
    private Animator animator;

    private void Awake()
    {
        animator = syringeObject.GetComponent<Animator>();
    }

    private void Update()
    {
        if (!hasMoved && syringeObject.activeSelf && !isMoving)
        {
            StartCoroutine(MoveAndRotateProcess());
            isMoving = true;
        }
    }

    IEnumerator MoveAndRotateProcess()
    {
        isMoving = true;

        yield return MoveAndRotate(syringeObject, syringePivot);

        PlayAnimation();

        yield return new WaitForSeconds(animator.GetCurrentAnimatorStateInfo(0).length);

        // slide8 비활성화 처리
        if (slide8 != null)
        {
            slide8.SetActive(false);
        }

        // slide8이 비활성화되어 있을 때만 slide9를 활성화합니다.
        if (slide8 != null && !slide8.activeSelf)
        {
            slide9.SetActive(true);
        }

        hasMoved = true; // 이동을 한 번 했으므로 true로 설정
        isMoving = false;
    }

    void PlayAnimation()
    {
        if (animator != null)
        {
            animator.Play(animationName);
        }
    }

    IEnumerator MoveAndRotate(GameObject movingObject, GameObject targetPivot)
    {
        while (Quaternion.Angle(movingObject.transform.localRotation, targetPivot.transform.localRotation) > 0.01f)
        {
            movingObject.transform.localRotation = Quaternion.Slerp(movingObject.transform.localRotation, targetPivot.transform.localRotation, rotateSpeed * Time.deltaTime);
            yield return null;
        }
        movingObject.transform.localRotation = targetPivot.transform.localRotation;
    }
}

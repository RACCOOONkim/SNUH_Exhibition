using UnityEngine;
using UnityEngine.XR;

public class BloodCollect : MonoBehaviour
{
    // 이벤트 핸들러 정의
    public delegate void OnLeftHandTriggerEnterEvent();
    public event OnLeftHandTriggerEnterEvent OnLeftHandTriggerEnter;

    public GameObject textToDisable;
    public GameObject textToEnable;
    public LayerMask triggerLayer; // "LeftHand" 레이어를 가리키도록 수정

    public float collisionDuration = 5f;

    private bool isColliding = false;
    private float collisionTimer = 0f;

    private void Update()
    {
        if (!isColliding)
        {
            CheckForCollision();
        }
        else
        {
            collisionTimer += Time.deltaTime;
            Debug.Log("Collider is detected");
            if (collisionTimer >= collisionDuration)
            {
                SwitchText();
            }
        }
    }

    private void CheckForCollision()
    {
        // 충돌 여부를 감지하고 이벤트 실행
        Collider[] colliders = Physics.OverlapSphere(transform.position, 0.1f);
        foreach (var collider in colliders)
        {
            // "LeftHand" 레이어를 갖는 오브젝트와 충돌했는지 확인
            if (collider.gameObject.layer == LayerMask.NameToLayer("LeftHand")) // "LeftHand" 레이어를 가리키도록 수정
            {
                isColliding = true;
                // 이벤트 실행
                if (OnLeftHandTriggerEnter != null)
                    OnLeftHandTriggerEnter();
                break;
            }
        }
    }

    private void SwitchText()
    {
        if (textToDisable != null)
        {
            textToDisable.SetActive(false);
        }

        if (textToEnable != null)
        {
            textToEnable.SetActive(true);
        }

        isColliding = false;
        collisionTimer = 0f;
    }
}

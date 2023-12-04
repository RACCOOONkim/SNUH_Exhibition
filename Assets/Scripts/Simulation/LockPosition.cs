using UnityEngine;

public class LockPosition : MonoBehaviour
{
    private Vector3 initialPosition;

    private void Start()
    {
        // 초기 위치 저장
        initialPosition = transform.position;
    }

    private void LateUpdate()
    {
        // 위치를 초기 위치로 항상 재설정
        transform.position = initialPosition;
    }
}

using UnityEngine;

public class TeleportOnCollision : MonoBehaviour
{
    public Transform targetPosition; // 플레이어를 이동시킬 위치
    public Quaternion targetRotation; // 플레이어를 회전시킬 각도

    private void Start()
    {
        targetRotation = targetPosition.rotation; // 초기 설정: 목표 위치의 회전값
    }

    private void OnTriggerEnter(Collider other)
    {
        // 플레이어와의 충돌을 감지하면
        if (other.CompareTag("Player"))
        {
            other.transform.position = targetPosition.position; // 플레이어의 위치를 변경
            other.transform.rotation = targetRotation; // 플레이어의 회전을 변경
        }
    }
}

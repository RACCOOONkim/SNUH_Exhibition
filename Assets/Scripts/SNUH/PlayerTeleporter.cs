using UnityEngine;

public class PlayerTeleporter : MonoBehaviour
{
    public Transform playerTransform; // 플레이어의 Transform

    // 버튼 클릭 시 호출될 메소드
    public void MovePlayerTo(Transform targetTransform)
    {
        playerTransform.position = targetTransform.position;
        playerTransform.rotation = targetTransform.rotation;
    }
}

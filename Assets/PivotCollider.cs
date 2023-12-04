using UnityEngine;
using System;

public class PivotCollider : MonoBehaviour
{
    public GameObject targetObject; // 충돌을 감지할 오브젝트
    public AudioClip guideEndClip; // 재생하고 싶은 오디오 클립

    private AudioSource audioSource; // 오디오 소스

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }

        // targetObject의 콜라이더에 이벤트를 추가
        if (targetObject != null)
        {
            var collider = targetObject.GetComponent<Collider>();
            if (collider != null)
            {
                collider.isTrigger = true; // isTrigger를 활성화해 충돌을 감지할 수 있게 함
                collider.gameObject.AddComponent<TriggerEventForwarder>().OnTriggerEnterEvent += HandleOtherObjectCollision;
            }
        }
    }

    private void HandleOtherObjectCollision(Collider other)
    {
        PlayerManager.Instance.StopDrawingPath();
        Debug.Log("sound guideend ");
        PlayGuideEndSound();
    }

    private void PlayGuideEndSound()
    {
        if (guideEndClip != null)
        {
            audioSource.clip = guideEndClip;
            audioSource.Play();
        }
    }
}

// 다른 오브젝트의 충돌 이벤트를 전달하기 위한 스크립트
public class TriggerEventForwarder : MonoBehaviour
{
    public event Action<Collider> OnTriggerEnterEvent;

    private void OnTriggerEnter(Collider other)
    {
        OnTriggerEnterEvent?.Invoke(other);
    }
}

using UnityEngine;

public class SectionAudioController : MonoBehaviour
{
    [SerializeField]
    private GameObject[] targetObjects; // 시작부터 비활성화된 오브젝트들

    private AudioSource audioSource;
    private bool[] wasActive; // 해당 오브젝트가 이전 프레임에서 활성화되었는지 여부를 저장

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        wasActive = new bool[targetObjects.Length];

        for (int i = 0; i < targetObjects.Length; i++)
        {
            wasActive[i] = targetObjects[i].activeSelf; // 초기 상태 저장
        }
    }

    private void Update()
    {
        for (int i = 0; i < targetObjects.Length; i++)
        {
            // 오브젝트가 이전에 활성화되어 있었는데 현재 비활성화된 경우에만 체크
            if (wasActive[i] && !targetObjects[i].activeSelf)
            {
                PlayAudio();
            }
            wasActive[i] = targetObjects[i].activeSelf; // 현재 상태를 다음 프레임에 사용하기 위해 저장
        }
    }

    private void PlayAudio()
    {
        if (audioSource != null && !audioSource.isPlaying)
        {
            audioSource.Play();
        }
    }
}

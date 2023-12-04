using UnityEngine;

public class PlaySoundOnDisable : MonoBehaviour
{
    public AudioClip soundClip; // 재생하고 싶은 오디오 클립
    private AudioSource audioSource; // 오디오 소스

    private void OnDisable()
    {
        InitializeAudioSourceIfNeeded();
        PlaySound();
    }

    private void InitializeAudioSourceIfNeeded()
    {
        if (audioSource == null)
        {
            audioSource = GetComponent<AudioSource>();
            if (audioSource == null)
            {
                audioSource = gameObject.AddComponent<AudioSource>();
            }
        }
    }

    private void PlaySound()
    {
        if (soundClip != null)
        {
            audioSource.clip = soundClip;
            audioSource.Play();
        }
    }
}

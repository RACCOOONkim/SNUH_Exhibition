using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OculusButtonAudio : MonoBehaviour
{
    public OVRInput.Button buttonToCheck = OVRInput.Button.One; // A button on Oculus Touch controller
    public AudioClip audioClip;
    private AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }

        audioSource.clip = audioClip;
    }

    private void Update()
    {
        if (OVRInput.GetDown(buttonToCheck))
        {
            PlayAudio();
        }
    }

    private void PlayAudio()
    {
        if (audioClip != null && !audioSource.isPlaying)
        {
            audioSource.Play();
        }
    }
}

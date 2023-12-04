using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UISound : MonoBehaviour
{
    public AudioClip clickSound, okSound, returnSound, clearSound, whooshSound;
    public AudioSource audioSource;

    public void Click()
    {
        audioSource.Stop();
        audioSource.clip = clickSound;
        audioSource.Play();
    }
    
    public void OK()
    {
        audioSource.Stop();
        audioSource.clip = okSound;
        audioSource.Play();
    }
    
    public void Return()
    {
        audioSource.Stop();
        audioSource.clip = returnSound;
        audioSource.Play();
    }

    public void Clear()
    {
        audioSource.Stop();
        audioSource.clip = clearSound;
        audioSource.Play();
    }

    public void Whoosh()
    {
        audioSource.Stop();
        audioSource.clip = whooshSound;
        audioSource.Play();
    }
}

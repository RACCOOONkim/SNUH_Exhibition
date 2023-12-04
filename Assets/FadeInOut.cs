using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class FadeInOut : MonoBehaviour
{
    public Image image;
    public AudioSource whoosh;
    private void Start()
    {
        image.DOFade(1f, 0f);
        StartFadeIn();
    }

    public void StartFadeIn()
    {
        whoosh.Play();
        image.DOFade(0f, 1f).SetEase(Ease.InSine);
    }
    
    public void StartFadeOut()
    {
        whoosh.Play();
        image.DOFade(1f, 1f).SetEase(Ease.InSine);
        SceneManager.LoadScene("BloodCollction_kwangtai");
    }

}

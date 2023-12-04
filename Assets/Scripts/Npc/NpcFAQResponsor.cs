using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class NpcFAQResponsor : MonoBehaviour
{
    [SerializeField] private GameObject openFAQButtonUI;
    [SerializeField] private GameObject FAQUI;
    [SerializeField] private GameObject speechBubbleUI;
    public Image bubbleImage;
    public Sprite defaultSprite, endSprite;
    public AudioClip endGuideClip;
    [SerializeField] private AudioSource audioSource;
    public Transform mainUIPivot;
    private TextMeshProUGUI _speechBubbleText;

    private void Awake()
    {
        _speechBubbleText = speechBubbleUI.GetComponentInChildren<TextMeshProUGUI>();
        
        openFAQButtonUI.SetActive(false);
        FAQUI.SetActive(false);
        speechBubbleUI.SetActive(false);
    }

    public void SetOpenButtonActiveState(bool isOn)
    {
        if (isOn && !FAQUI.activeSelf) openFAQButtonUI.SetActive(true);
        else if(!isOn) openFAQButtonUI.SetActive(false);
    }

    public void UpdateAnswer(int index)
    {
        _speechBubbleText.text = NpcManager.Instance.scriptList[index].answer;
        audioSource.Stop();
        audioSource.clip = NpcManager.Instance.scriptList[index].answerClip;
    }
    
    public void StartResponse()
    {
        StartCoroutine(Response());
    }

    private IEnumerator Response()
    {
        FAQUI.SetActive(false);
        speechBubbleUI.SetActive(true);
        
        audioSource.Play();
        yield return new WaitForSeconds(audioSource.clip.length);

        speechBubbleUI.SetActive(false);
        openFAQButtonUI.SetActive(false);
        
        if (NpcManager.Instance.scriptList.Count > 0) FAQUI.SetActive(true);
        else FAQUI.SetActive(false);
    }

    public void WhenGuideEnd()
    {
        StartCoroutine(ResponseEnd());
    }

    private IEnumerator ResponseEnd()
    {
        _speechBubbleText.text = "";
        NpcManager.Instance.SetDefaultPosition();
        FAQUI.SetActive(false);
        speechBubbleUI.SetActive(true);
        bubbleImage.sprite = endSprite;
        audioSource.clip = endGuideClip;
        audioSource.Play();
        yield return new WaitForSeconds(audioSource.clip.length);

        speechBubbleUI.SetActive(false);
        FAQUI.SetActive(false);
        openFAQButtonUI.SetActive(true);
        bubbleImage.sprite = defaultSprite;
    }
}

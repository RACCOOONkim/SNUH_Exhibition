using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class ButtonGroupGenerator : MonoBehaviour
{
    [SerializeField] private Transform buttonGroup;
    [SerializeField, Range(0f, 1f)] private float intervalTime = 0.5f;
    [SerializeField, Range(0f, 1f)] private float floatingTime = 0.5f;
    [SerializeField, Range(0f, 1f)] private float floatingDistance = 0.5f;
    [SerializeField] private Ease ease;
    
    private Transform[] _buttons;
    private Image[] _images;
    private Vector3[] _defaultLocalPositions;

    private void Awake()
    {
        var count = buttonGroup.childCount;
        _buttons = new Transform[count];
        _images = new Image[count];
        _defaultLocalPositions = new Vector3[count];
        
        for (int i = buttonGroup.childCount - 1; i >= 0; i--)
        {
            _buttons[i] = buttonGroup.GetChild(i);
            _images[i] = buttonGroup.GetChild(i).GetComponent<Image>();
            _defaultLocalPositions[i] = buttonGroup.GetChild(i).localPosition;
        }
    }

    private void Initiate()
    {
        for(int i = 0; i < _buttons.Length; i++)
        {
            _buttons[i].gameObject.SetActive(false);
            _buttons[i].DOKill();
            _images[i].DOFade(0f, 0f);
            _images[i].DOKill();
        }
    }

    public IEnumerator Generate()
    {
        var waitForSeconds = new WaitForSeconds(intervalTime);
        Initiate();
        
        for(int i = 0; i < _buttons.Length; i++)
        {
            _buttons[i].gameObject.SetActive(true);
            _buttons[i].localPosition = _defaultLocalPositions[i] - new Vector3(0f, floatingDistance, 0f);
            _buttons[i].DOLocalMoveY(_defaultLocalPositions[i].y, floatingTime).SetEase(ease);
            _images[i].DOFade(250/255f, floatingTime).SetEase(ease);
            yield return waitForSeconds;
        }
    }
}

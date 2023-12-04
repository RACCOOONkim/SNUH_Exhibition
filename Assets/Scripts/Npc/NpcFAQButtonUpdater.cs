using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;

public class NpcFAQButtonUpdater : MonoBehaviour
{
    [SerializeField] private GameObject[] buttons;
    private TextMeshProUGUI[] _buttonTexts;

    private void Awake()
    {
        _buttonTexts = new TextMeshProUGUI[buttons.Length];
        for (int i = 0; i < buttons.Length; i++)
        {
            _buttonTexts[i] = buttons[i].GetComponentInChildren<TextMeshProUGUI>();
        }
    }

    public void UpdateFAQButtons()
    {
        for (int i = 0; i < buttons.Length; i++)
        {
            buttons[i].SetActive(false);
        }

        for (int i = 0; i < NpcManager.Instance.scriptList.Count; i++)
        {
            buttons[i].SetActive(true);
            _buttonTexts[i].text = NpcManager.Instance.scriptList[i].question;
        }
    }
}

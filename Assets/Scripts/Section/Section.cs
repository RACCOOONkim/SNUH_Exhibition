using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Section : MonoBehaviour
{
    //[SerializeField] private Section nextSection;
    public Transform pivot;
    public GameObject col;
    [SerializeField] private GameObject uis;
    [SerializeField] private GameObject markers;

    private NpcFAQScriptProvider _npcFaqScriptProvider;

    private void Awake()
    {
        _npcFaqScriptProvider = GetComponent<NpcFAQScriptProvider>();
        
        SetInfoUIActiveState(false);
    }

    public void OnSectionEnter()
    {
        NpcManager.Instance.scriptList = _npcFaqScriptProvider.ProvideScriptList();
        NpcManager.Instance.UpdateFAQButtons();
        NpcManager.Instance.SetOpenButtonActiveState(true);
        
        SetInfoUIActiveState(true);
    }

    public void OnSectionExit()
    {
        NpcManager.Instance.scriptList = _npcFaqScriptProvider.ClearScriptList();
        NpcManager.Instance.UpdateFAQButtons();
        NpcManager.Instance.SetOpenButtonActiveState(false);
        
        SetInfoUIActiveState(false);
        col.SetActive(false);
    }

    private void SetInfoUIActiveState(bool isOn) //Turn On/Off UIs & Markers
    {
        uis.SetActive(isOn);
        markers.SetActive(isOn);
    }
}
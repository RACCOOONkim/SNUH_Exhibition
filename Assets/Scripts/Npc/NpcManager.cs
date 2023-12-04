using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NpcManager : MonoBehaviour
{
    public static NpcManager Instance;
    public List<FAQScript> scriptList;
    public Transform defaultPivot;
    public Transform mainUIPivot;
    private NpcFAQButtonUpdater _buttonUpdater;
    private NpcFAQResponsor _faqResponsor;
    private NavmeshMovement _navmeshMovement;

    private void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(this);

        _buttonUpdater = GetComponentInChildren<NpcFAQButtonUpdater>();
        _faqResponsor = GetComponentInChildren<NpcFAQResponsor>();
        _navmeshMovement = GetComponentInChildren<NavmeshMovement>();
    }

    public void UpdateFAQButtons()
    {
        _buttonUpdater.UpdateFAQButtons();
    }

    public void SetOpenButtonActiveState(bool isOn)
    {
        _faqResponsor.SetOpenButtonActiveState(isOn);
    }

    public void WhenGuideEnd()
    {
        _faqResponsor.WhenGuideEnd();
    }

    public void SetDefaultPosition()
    {
        _navmeshMovement.ChangePivot(defaultPivot);
        _navmeshMovement.SetPosition();
    }
    
    public void SetMainUIPosition()
    {
        _navmeshMovement.ChangePivot(mainUIPivot);
        _navmeshMovement.SetPosition();
    }
}

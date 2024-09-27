using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Serialization;

public class MainUI : MonoBehaviour
{
    [Header("Setting")]
    [SerializeField] private Transform wrist;
    [SerializeField] private Transform uiPivot;
    [SerializeField, Range(0.5f, 5f)] private float yOffset = 2f;
    [SerializeField, Range(0.5f, 5f)] private float zOffset = 2f;

    [Space(10), Header("Reference")]
    [SerializeField] private ButtonGroupGenerator parentButtonUI;
    [SerializeField] private NavmeshMovement navmeshMovement;
    [SerializeField] private NavmeshMovement npcNavmeshMovement;
    [SerializeField] private Transform defaultPivot, uiActivePivot;
    private bool _isOn;
    private List<GameObject> _children;
    private Coroutine _coroutine;
    private NavMeshAgent _agent;
    
    private void Start()
    {

        _agent = GetComponent<NavMeshAgent>();
        _children = new List<GameObject>();
        
        parentButtonUI.transform.localPosition = new Vector3(0f, yOffset, 0f);
        uiPivot.localPosition = new Vector3(0f, 0f, zOffset);
        
        for (int i = 0; i < transform.childCount; i++)
        {
            _children.Add(transform.GetChild(i).gameObject);
            _children[i].SetActive(false);
        }
    }

    public void ToggleState()
    {
        _isOn = !_isOn;
        transform.position = PlayerManager.Instance.eyeTransform.position + transform.forward;
        foreach (var child in _children)
        {
            child.SetActive(false);
        }
        if (_isOn)
        {
            _agent.enabled = true;
            if (navmeshMovement != null)
                navmeshMovement.enabled = true;
            GenerateParentUI();
            if(npcNavmeshMovement!=null)
            npcNavmeshMovement.ChangePivot(uiActivePivot);
        }
        else
        {
            if(navmeshMovement!=null)
            navmeshMovement.enabled = false;
            _agent.enabled = false;
            if (npcNavmeshMovement != null)
                npcNavmeshMovement.ChangePivot(defaultPivot);
        }
    }

    private void GenerateParentUI()
    {
        parentButtonUI.gameObject.SetActive(true);
        if(_coroutine != null) StopCoroutine(_coroutine);
        _coroutine = StartCoroutine(parentButtonUI.Generate());
    }
}

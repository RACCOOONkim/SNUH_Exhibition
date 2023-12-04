using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NavmeshMovement : MonoBehaviour
{
    public Transform target;
    private NavMeshAgent _agent;

    private void Awake()
    {
        _agent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        _agent.SetDestination(target.position);
    }

    public void SetPosition()
    {
        transform.position = target.position;
    }

    private void OnEnable()
    {
        SetPosition();
    }

    public void ChangePivot(Transform pivot)
    {
        target = pivot;
    }
}

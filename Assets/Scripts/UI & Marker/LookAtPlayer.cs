using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtPlayer : MonoBehaviour
{
    private Transform _player;
    public bool reverse;

    private void Start()
    {
        _player = PlayerManager.Instance.eyeTransform;
    }

    private void Update()
    {
        if (reverse) transform.LookAt(_player.position);
        else transform.LookAt(2 * transform.position - _player.position);
    }
}

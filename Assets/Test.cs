using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class Test : MonoBehaviour
{
    private void Start()
    {
        transform.DORotate(new Vector3(0, 380, 0), 2f);
        //DOVirtual.Float(0, 360 * 1000, 10000f, Turn);
    }

    private void Turn(float a)
    {
        Debug.Log(a/360);
        transform.Rotate(new Vector3(0, a, 0), Space.Self);
    }
}

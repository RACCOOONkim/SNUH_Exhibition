using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public static PlayerManager Instance;

    public UISound uiSound;
    public Transform playerTransform;
    public Transform eyeTransform;

    private PathDrawer _pathDrawer;


    
    private void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(this);

        _pathDrawer = GetComponent<PathDrawer>();
    }

    public void StopDrawingPath()
    {
        _pathDrawer.StopDrawingPath();
        uiSound.Clear();
    }

    public void StartDrawingPath()
    {
        _pathDrawer.StartDrawingPath();
    }


}

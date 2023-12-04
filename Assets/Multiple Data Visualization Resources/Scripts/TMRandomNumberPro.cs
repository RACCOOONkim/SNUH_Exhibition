﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class TMRandomNumberPro : MonoBehaviour
{
    //public Text numText;
    public TextMeshProUGUI numText;

    public float interval;
    public float initInterval;

    public int min=1;
    public int Max=999;
    // Start is called before the first frame update
    void Start()
    {
        initInterval = Random.Range(0.1f, 0.5f);
        numText = GetComponent<TextMeshProUGUI>();
    }
    
    // Update is called once per frame
    void Update()
    {
        interval -= Time.deltaTime;
        if(interval<=0f)
        {
            numText.text = Random.Range(min, Max).ToString();
            interval = initInterval;
        }

    }
}

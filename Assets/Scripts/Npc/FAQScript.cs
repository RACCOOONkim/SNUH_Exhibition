using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class FAQScript
{

    [TextArea(3, 3)] public string question;
    [Space(10)]
    [TextArea(3, 3)] public string answer;
    public AudioClip answerClip;
}

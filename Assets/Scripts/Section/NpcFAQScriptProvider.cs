using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NpcFAQScriptProvider : MonoBehaviour
{
    public List<FAQScript> scripts;
    public List<FAQScript> ProvideScriptList()
    {
        return scripts;
    }

    public List<FAQScript> ClearScriptList()
    {
        return new List<FAQScript>();
    }
}

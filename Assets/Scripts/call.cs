using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class call : MonoBehaviour
{
    public Button yourButton; // Set this in the Unity Editor.

    // Start is called before the first frame update
    void Start()
    {
        // Add a listener to the button for when the click event is called.
        yourButton.onClick.AddListener(Call12);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Call12()
    {
        Debug.Log(12);
    }
}
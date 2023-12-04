using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;



public class ButtonTester : MonoBehaviour
{
    [SerializeField]
    private GameObject objOn;
    [SerializeField]
    private GameObject objOff;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }


    // GameObject를 활성화하는 함수
    public void ActivateObject()
    {
        if (objOn != null)
        {
            objOn.SetActive(true);


        }
    }

    // GameObject를 비활성화하는 함수
    public void DeactivateObject()
    {
        if (objOff != null)
        {
            objOff.SetActive(false);


        }
    }


}

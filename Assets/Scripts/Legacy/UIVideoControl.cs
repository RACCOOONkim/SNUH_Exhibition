using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class UIVideoControl : MonoBehaviour
{
    public VideoPlayer video;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void VidReplay() 
    {
        Debug.Log("ó������ �ٽ� ���");
        video.time = 0;
    }
    public void VidPlay()
    {
        Debug.Log("���� ���������� ���");
        video.Play();
    }
    public void VidPause() 
    {
        Debug.Log("�Ͻ�����");
        video.Pause();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class PlayerController : MonoBehaviour
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
        Debug.Log("처음부터 다시 재생");
        video.time = 0;
    }
    public void VidPlay()
    {
        Debug.Log("멈춘 곳에서부터 재생");
        video.Play();
    }
    public void VidPause() 
    {
        Debug.Log("일시정지");
        video.Pause();
    }
}

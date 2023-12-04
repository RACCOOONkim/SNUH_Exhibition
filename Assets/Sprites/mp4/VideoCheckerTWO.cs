using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class VideoCheckerTWO : MonoBehaviour
{
    public VideoPlayer vid = null;
    public GameObject VideoFrame = null;
    public VideoPlayer vid2 = null;
    public GameObject VideoFrame2 = null;


    void Start() 
    { 
        vid.loopPointReached += CheckOver;
        
        VideoFrame2.SetActive(false);
    }

    void CheckOver(UnityEngine.Video.VideoPlayer vp)
    {
        print("Video Is Over");
        VideoFrame.SetActive(false);
        VideoFrame2.SetActive(true);
        vid2.loopPointReached += CheckOver2;
    }
    void CheckOver2(UnityEngine.Video.VideoPlayer vp2)
    {
        print("Video2 Is Over");
        VideoFrame2.SetActive(false);
        SceneManager.LoadScene("03_recovery_room");
    }

}


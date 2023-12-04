using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class VideoChecker : MonoBehaviour
{
    public VideoPlayer vid;
    public GameObject VideoFrame = null;
    Scene scene;
    public bool IsThisSurgeryRoom = false;
    public bool IsThisLastRoom = false;
    void Start()
    {
        vid.loopPointReached += CheckOver;
        scene = SceneManager.GetActiveScene();
    }

    void CheckOver(UnityEngine.Video.VideoPlayer vp)
    {
        print("Video Is Over");
        VideoFrame.SetActive(false);
        if (IsThisSurgeryRoom == true)
        {
            SceneManager.LoadScene("03_recovery_room");
            //    Debug.Log("next : recovery room");
        }
        if (IsThisLastRoom == true)
        {
            SceneManager.LoadScene("00_mainroom");
            //    Debug.Log("next : recovery room");
        }
    }

}

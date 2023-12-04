using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class LoadScene : MonoBehaviour
{
    // Start is called before the first frame update
    Scene scene;
   
    
    void Start()
    {
        scene = SceneManager.GetActiveScene();
       
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
   
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player") 
        {
            switch (scene.name)
            {
                case "01_room":
                    SceneManager.LoadScene("02_0_surgery_enter");
                    Debug.Log("next : surgery enter");
                    break;
                case "02_0_surgery_enter":
                    SceneManager.LoadScene("02_room_hallway");
                    Debug.Log("next : surgery room");
                    break;
                //case "02_room_hallway":
                //    SceneManager.LoadScene("03_recovery_room");
                //    Debug.Log("next : recovery room");
                //    break;
                case "03_recovery_room":
                    SceneManager.LoadScene("04_room_back");
                    break;
            }
        }
    }
    
}

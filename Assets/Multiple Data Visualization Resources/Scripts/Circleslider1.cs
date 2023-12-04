using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Circleslider1 : MonoBehaviour
{
    public bool b = true;
    public Image image;
    public float speed = 0.5f;
    public float targetFillAmount = 0.91f; // 원하는 fillAmount 값을 저장할 변수
    float time = 0f;
    public Text progress;

    void Update()
    {
        if (b)
        {
            time += Time.deltaTime * speed;
            image.fillAmount = time;
            if (progress)
            {
                progress.text = (int)(image.fillAmount * 100) + "%";
            }

            // image의 fillAmount 값이 targetFillAmount 값에 도달하면 b를 false로 변경하여 슬라이더가 멈추도록 함
            if (image.fillAmount >= targetFillAmount)
            {
                b = false;
            }
        }
    }
}

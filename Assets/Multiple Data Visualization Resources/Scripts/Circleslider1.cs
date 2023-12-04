using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Circleslider1 : MonoBehaviour
{
    public bool b = true;
    public Image image;
    public float speed = 0.5f;
    public float targetFillAmount = 0.91f; // ���ϴ� fillAmount ���� ������ ����
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

            // image�� fillAmount ���� targetFillAmount ���� �����ϸ� b�� false�� �����Ͽ� �����̴��� ���ߵ��� ��
            if (image.fillAmount >= targetFillAmount)
            {
                b = false;
            }
        }
    }
}

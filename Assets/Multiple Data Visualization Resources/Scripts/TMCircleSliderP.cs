/*
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TMCircleSliderP : MonoBehaviour
{
    public bool b = true;
    public Image image;
    public Image image1; // 2023, 2024에서 사용할 Image
    public float delay = 1f; // 다음 time 값으로 변경되기까지의 딜레이 시간
    public float lerpSpeed = 0.005f; // 이미지와 숫자가 움직이는 속도를 더 천천히 하도록 수정

    // time 값과 그에 해당하는 년도를 저장하는 Dictionary
    private Dictionary<float, string> timeYearMap = new Dictionary<float, string>()
    {
        { 88.39f, "2018" },
        { 91.72f, "2019" },
        { 99.82f, "2020" },
        { 97.60f, "2021" },
        { 97.90f, "2022" },
        { 98.20f, "2023" },
        { 98.50f, "2024" },
    };

    public TextMeshProUGUI progress; // time 값을 표시할 TextMeshProUGUI
    public TextMeshProUGUI progress1; // 년도를 표시할 TextMeshProUGUI

    private void Start()
    {
        if (b)
        {
            StartCoroutine(TimeChangeCoroutine());
        }
    }

    IEnumerator TimeChangeCoroutine()
    {
        while (true) // 무한 반복
        {
            foreach (var timeYear in timeYearMap)
            {
                float targetTime = timeYear.Key / 100; // fillAmount는 0.0 ~ 1.0 범위이므로 100으로 나누어줍니다.
                float currentTime = image.fillAmount; // image의 현재 fillAmount

                // 년도가 2023, 2024일 때는 image1을 사용하고, 그 외에는 image를 사용합니다.
                if (timeYear.Value == "2023" || timeYear.Value == "2024")
                {
                    currentTime = image1.fillAmount; // image1의 현재 fillAmount
                    image1.gameObject.SetActive(true);  // image1을 활성화합니다.
                    image.gameObject.SetActive(false);  // image를 비활성화합니다.
                }
                else
                {
                    image.gameObject.SetActive(true);  // image를 활성화합니다.
                    image1.gameObject.SetActive(false);  // image1을 비활성화합니다.
                }

                progress1.text = timeYear.Value; // 년도 표시

                // currentTime이 targetTime에 도달할 때까지 부드럽게 움직입니다.
                while (Mathf.Abs(currentTime - targetTime) > 0.001f)
                {
                    currentTime = Mathf.Lerp(currentTime, targetTime, lerpSpeed);
                    progress.text = (currentTime * 100).ToString("0.00") + "%"; // time 값에 '%'를 붙여 표시

                    if (timeYear.Value == "2023" || timeYear.Value == "2024")
                    {
                        image1.fillAmount = currentTime;
                    }
                    else
                    {
                        image.fillAmount = currentTime;
                    }

                    yield return null; // 한 프레임 대기
                }

                // time 값이 목표값에 도달했을 때 progress.text를 목표 time 값으로 직접 설정
                progress.text = (targetTime * 100).ToString("0.00") + "%";

                yield return new WaitForSeconds(delay); // time 값이 목표 값에 도달했을 때 잠시 멈추고 다음 time 값으로 변경되기까지의 딜레이 시간 대기
            }
        }
    }
}
*/


using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TMCircleSliderP : MonoBehaviour
{
    public bool b = true;
    public Image image;
    public Image image1; // 2023, 2024에서 사용할 Image
    public float delay = 1f; // 다음 time 값으로 변경되기까지의 딜레이 시간
    public float lerpSpeed = 0.005f; // 이미지와 숫자가 움직이는 속도를 더 천천히 하도록 수정

    // time 값과 그에 해당하는 년도를 저장하는 Dictionary
    private Dictionary<float, string> timeYearMap = new Dictionary<float, string>()
    {
        { 88.39f, "2018" },
        { 91.72f, "2019" },
        { 99.82f, "2020" },
        { 97.60f, "2021" },
        { 97.90f, "2022" },
        { 98.20f, "2023" },
        { 98.50f, "2024" },
    };

    public TextMeshProUGUI progress; // time 값을 표시할 TextMeshProUGUI
    public TextMeshProUGUI progress1; // 년도를 표시할 TextMeshProUGUI

    private void Start()
    {
        if (b)
        {
            StartCoroutine(TimeChangeCoroutine());
        }
    }

    IEnumerator TimeChangeCoroutine()
    {
        while (true) // 무한 반복
        {
            foreach (var timeYear in timeYearMap)
            {
                float targetTime = timeYear.Key / 100; // fillAmount는 0.0 ~ 1.0 범위이므로 100으로 나누어줍니다.
                float currentTime = image.fillAmount; // image의 현재 fillAmount

                // 년도가 2023, 2024일 때는 image1을 사용하고, 그 외에는 image를 사용합니다.
                if (timeYear.Value == "2023" || timeYear.Value == "2024")
                {
                    currentTime = image1.fillAmount; // image1의 현재 fillAmount
                    image1.gameObject.SetActive(true);  // image1을 활성화합니다.
                    image.gameObject.SetActive(false);  // image를 비활성화합니다.

                    Color newColor;
                    if (ColorUtility.TryParseHtmlString("#02E375", out newColor))
                    {
                        progress1.color = newColor; // progress1의 색상을 #02E375로 설정
                    }
                }
                else
                {
                    image.gameObject.SetActive(true);  // image를 활성화합니다.
                    image1.gameObject.SetActive(false);  // image1을 비활성화합니다.
                    progress1.color = Color.white; // progress1의 색상을 흰색으로 설정
                }

                progress1.text = timeYear.Value; // 년도 표시

                // currentTime이 targetTime에 도달할 때까지 부드럽게 움직입니다.
                while (Mathf.Abs(currentTime - targetTime) > 0.001f)
                {
                    currentTime = Mathf.Lerp(currentTime, targetTime, lerpSpeed);
                    progress.text = (currentTime * 100).ToString("0.00") + "%"; // time 값에 '%'를 붙여 표시

                    if (timeYear.Value == "2023" || timeYear.Value == "2024")
                    {
                        image1.fillAmount = currentTime;
                    }
                    else
                    {
                        image.fillAmount = currentTime;
                    }

                    yield return null; // 한 프레임 대기
                }

                // time 값이 목표값에 도달했을 때 progress.text를 목표 time 값으로 직접 설정
                progress.text = (targetTime * 100).ToString("0.00") + "%";

                yield return new WaitForSeconds(delay); // time 값이 목표 값에 도달했을 때 잠시 멈추고 다음 time 값으로 변경되기까지의 딜레이 시간 대기
            }
        }
    }
}

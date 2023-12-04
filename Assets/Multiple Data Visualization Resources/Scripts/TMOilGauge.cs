using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TMOilGauge : MonoBehaviour
{
    // b 변수는 기름 게이지의 채워짐을 제어하기 위한 boolean 타입 변수입니다.
    public bool b = true;

    // image 변수는 기름 게이지를 표현하는 UI 이미지입니다.
    public Image image;

    // speed 변수는 기름 게이지가 얼마나 빠르게 채워지는지 제어하는 속도 변수입니다.
    public float speed = 0.5f;

    // time 변수는 게이지 진행 상황을 추적하기 위한 시간 변수입니다.
    float time = 0f;

    // progress 변수는 게이지의 진행 상황을 표시하는 TextMeshProUGUI 객체입니다.
    public TextMeshProUGUI progress;
    public TextMeshProUGUI year;

    // oilOilGaugePivot 변수는 기름 게이지의 회전을 제어하기 위한 피벗(Transform)입니다.
    public Transform oilOilGaugePivot;

    // Update 함수는 매 프레임마다 호출되는 함수입니다.
    void Update()
    {
        // b가 true일 때만 기름 게이지가 채워지도록 합니다.
        if (b)
        {
            // time 값을 증가시킵니다. 증가하는 속도는 speed에 의해 제어됩니다.
            time += Time.deltaTime * speed;

            // image의 fillAmount를 time 값으로 설정하여 기름 게이지를 채웁니다.
            image.fillAmount = time;

            // oilOilGaugePivot의 로컬 회전값을 설정하여 기름 게이지의 회전을 제어합니다.
            oilOilGaugePivot.localEulerAngles = Vector3.forward * (90 - 180 * image.fillAmount);

            // progress가 null이 아닐 경우, 게이지의 진행 상황을 텍스트로 표시합니다.
            if (progress)
            {
                progress.text = ((int)(image.fillAmount * 100)).ToString();
            }

            // time 값이 1을 초과하면 time을 0으로 초기화합니다. 이는 기름 게이지가 다 채워진 후 다시 비워지는 동작을 구현하는 것입니다.
            if (time > 1)
            {
                time = 0;
            }
        }
    }
}

using UnityEngine;
using UnityEngine.UI;

public class SliderRunTo1A : MonoBehaviour
{
    // 슬라이더가 활성화되어 있는지를 결정하는 불리언 변수입니다.
    public bool b = true;
    // 슬라이더 컴포넌트에 대한 참조입니다.
    public Slider slider;
    // 슬라이더 값이 증가하는 속도를 결정하는 변수입니다.
    public float speed = 0.5f;
    // Inspector에서 설정할 슬라이더의 최대 값입니다.
    public float maxSliderValue = 1f;

    void Start()
    {
        // 스크립트가 부착된 게임오브젝트에서 Slider 컴포넌트를 가져옵니다.
        slider = GetComponent<Slider>();
    }

    void Update()
    {
        // b가 true일 때 슬라이더 값을 증가시킵니다.
        if (b)
        {
            // 슬라이더의 현재 값을 증가시키고, 이 값을 슬라이더의 값으로 설정합니다.
            slider.value += Time.deltaTime * speed;

            // 만약 슬라이더의 값이 Inspector에서 설정한 최대 값보다 크거나 같으면 슬라이더를 멈춥니다.
            if (slider.value >= maxSliderValue)
            {
                b = false;
            }
        }
    }
}



using UnityEngine;
using UnityEngine.UI;

public class LineSliderP : MonoBehaviour
{
    public bool b = true;
    public Image image;
    public float speed = 0.5f;

    float time = 0f;

    // 원하는 fillAmount 값을 저장할 변수입니다. Inspector 창에서 조절할 수 있습니다.
    public float targetFillAmount = 1f;

    private void Start()
    {
        image = GetComponent<Image>();
        speed = Random.Range(0.2f, 0.6f);
    }

    void Update()
    {
        if (b)
        {
            time += Time.deltaTime * speed;
            image.fillAmount = time;

            // time이 targetFillAmount에 도달하거나 초과하면 이미지 채움 업데이트를 멈추고, b를 false로 설정합니다.
            if (time >= targetFillAmount)
            {
                b = false;
            }
        }
    }
}


// fillamount 값에 도달하면 다시 0부터 이미지 움직이는 코드
/*
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TMLineSliderP : MonoBehaviour
{

    public bool b = true;
    public Image image;
    public float speed = 0.5f;

    float time = 0f;

    //public Text progress;
    public TextMeshProUGUI progress;

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
            // time을 targetFillAmount으로 나눈 나머지를 이미지의 채움 양으로 설정하여 targetFillAmount 값 안에서 이미지가 움직이도록 합니다.
            image.fillAmount = time % targetFillAmount;
            if (progress)
            {
                progress.text = (int)(image.fillAmount * 100) + "%";
            }
        }
    }

}
*/

// fillamount값에 도달하면 멈추는 코드
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TMLineSliderP : MonoBehaviour
{

    public bool b = true;
    public Image image;
    public float speed = 0.5f;

    float time = 0f;

    //public Text progress;
    public TextMeshProUGUI progress;

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
            if (progress)
            {
                progress.text = (int)(image.fillAmount * 100) + "%";
            }

            // time이 targetFillAmount에 도달하거나 초과하면 이미지 채움 업데이트를 멈추고, b를 false로 설정합니다.
            if (time >= targetFillAmount)
            {
                b = false;
            }
        }
    }

}

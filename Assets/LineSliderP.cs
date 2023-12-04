using UnityEngine;
using UnityEngine.UI;

public class LineSliderP : MonoBehaviour
{
    public bool b = true;
    public Image image;
    public float speed = 0.5f;

    float time = 0f;

    // ���ϴ� fillAmount ���� ������ �����Դϴ�. Inspector â���� ������ �� �ֽ��ϴ�.
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

            // time�� targetFillAmount�� �����ϰų� �ʰ��ϸ� �̹��� ä�� ������Ʈ�� ���߰�, b�� false�� �����մϴ�.
            if (time >= targetFillAmount)
            {
                b = false;
            }
        }
    }
}



using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TMThreeCirclePercent : MonoBehaviour
{
    [Range(0.01f, 9999)]
    public float no1, no2, no3;

    public Image a, b, c;

    public TextMeshProUGUI t1, t2, t3;

    public float rotationSpeed = 10f;

    void Start()
    {
        UpdatePercent(no1, no2, no3);
    }

    void Update()
    {
        RotateCircles();
    }

    public void UpdatePercent(float n1, float n2, float n3)
    {
        float sum = n1 + n2 + n3;

        float p1 = n1 / sum;
        float p2 = n2 / sum;
        float p3 = n3 / sum;

        a.fillAmount = p1;
        b.fillAmount = p2;
        c.fillAmount = p3;

        t1.text = (int)(p1 * 100) + "%";
        t2.text = (int)(p2 * 100) + "%";
        t3.text = (int)(p3 * 100) + "%";
    }

    public void RotateCircles()
    {
        a.transform.Rotate(Vector3.back, rotationSpeed * Time.deltaTime);
        b.transform.Rotate(Vector3.back, rotationSpeed * Time.deltaTime);
        c.transform.Rotate(Vector3.back, rotationSpeed * Time.deltaTime);
    }
}

using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class StaticImageDisplay : MonoBehaviour
{
    public float displayDuration = 3.0f; // 이미지가 완전히 표시되는 데 걸리는 시간
    public GameObject toolObject; 

    private Image displayImage;
    private Color originalColor;

    private void Awake()
    {
        displayImage = GetComponent<Image>();
        originalColor = displayImage.color;
        displayImage.color = new Color(originalColor.r, originalColor.g, originalColor.b, 0); // 초기 투명도를 0으로 설정
    }

    private void Start()
    {
        StartCoroutine(FadeInImage());
    }

    private IEnumerator FadeInImage()
    {
        float elapsedTime = 0f;
        while (elapsedTime < displayDuration)
        {
            float alpha = Mathf.Lerp(0, originalColor.a, elapsedTime / displayDuration);
            displayImage.color = new Color(originalColor.r, originalColor.g, originalColor.b, alpha);
            elapsedTime += Time.deltaTime;
            yield return null;
        }
        displayImage.color = originalColor;

        if (toolObject != null)
        {
            toolObject.SetActive(true);
        }
    }
}

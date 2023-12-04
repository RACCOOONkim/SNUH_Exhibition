using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class StaticImageFor7 : MonoBehaviour
{
    public float fadeInDuration = 3.0f;
    public float fadeOutDuration = 2.0f;  // 페이드 아웃하는 데 걸리는 시간 추가
    public GameObject catheterObject;
    public GameObject bandageObject;
    public GameObject slide8;
    public GameObject slide7;
    
    private Image displayImage;
    private Color originalColor;

    private void Awake()
    {
        displayImage = GetComponent<Image>();
        originalColor = displayImage.color;
        displayImage.color = new Color(originalColor.r, originalColor.g, originalColor.b, 0);
    }

    private void Start()
    {
        StartCoroutine(FadeInImage());
    }

    private IEnumerator FadeInImage()
    {
        float elapsedTime = 0f;
        while (elapsedTime < fadeInDuration)
        {
            float alpha = Mathf.Lerp(0, originalColor.a, elapsedTime / fadeInDuration);
            displayImage.color = new Color(originalColor.r, originalColor.g, originalColor.b, alpha);
            elapsedTime += Time.deltaTime;
            yield return null;
        }
        displayImage.color = originalColor;

        if (catheterObject != null)
        {
            catheterObject.SetActive(true);
            yield return new WaitForSeconds(1f);

            if (bandageObject != null)
            {
                bandageObject.SetActive(true);
                yield return new WaitForSeconds(5f); // 밴드 다 움직이고 나서 비활성화
                
                // slide7 페이드 아웃
                elapsedTime = 0f;
                while (elapsedTime < fadeOutDuration)
                {
                    float alpha = Mathf.Lerp(originalColor.a, 0, elapsedTime / fadeOutDuration);
                    displayImage.color = new Color(originalColor.r, originalColor.g, originalColor.b, alpha);
                    elapsedTime += Time.deltaTime;
                    yield return null;
                }
                displayImage.color = new Color(originalColor.r, originalColor.g, originalColor.b, 0);

                if (slide8 != null)
                {
                    slide8.SetActive(true);
                    slide7.SetActive(false);
                }
            }
        }
    }
}

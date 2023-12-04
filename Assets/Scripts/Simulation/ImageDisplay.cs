using System.Collections.Generic; // List를 사용하기 위해 추가
using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ImageDisplay : MonoBehaviour
{
    public float fadeInDuration = 3.0f;
    public float displayDuration = 5.0f;
    public float fadeOutDuration = 2.0f;
    public List<GameObject> nextObject = new List<GameObject>(); // 다음 이미지 UI 오브젝트들

    private Image imageUI;
    private Color originalColor;

    private void Awake()
    {
        imageUI = GetComponent<Image>();
        originalColor = imageUI.color;
        imageUI.color = new Color(originalColor.r, originalColor.g, originalColor.b, 0);
    }

    private void Start()
    {
        StartCoroutine(DisplayImageSequence());
    }

    private IEnumerator DisplayImageSequence()
    {
        // Fade in
        float elapsedFadeInTime = 0f;
        while (elapsedFadeInTime < fadeInDuration)
        {
            float alpha = Mathf.Lerp(0, originalColor.a, elapsedFadeInTime / fadeInDuration);
            imageUI.color = new Color(originalColor.r, originalColor.g, originalColor.b, alpha);
            elapsedFadeInTime += Time.deltaTime;
            yield return null;
        }
        imageUI.color = originalColor;

        // Display for a duration
        yield return new WaitForSeconds(displayDuration);

        // Fade out
        float elapsedFadeOutTime = 0f;
        while (elapsedFadeOutTime < fadeOutDuration)
        {
            float alpha = Mathf.Lerp(originalColor.a, 0, elapsedFadeOutTime / fadeOutDuration);
            imageUI.color = new Color(originalColor.r, originalColor.g, originalColor.b, alpha);
            elapsedFadeOutTime += Time.deltaTime;
            yield return null;
        }
        imageUI.color = new Color(originalColor.r, originalColor.g, originalColor.b, 0);

        // Move to the next image UIs
        foreach (var nextImage in nextObject)
        {
            if (nextImage != null)
            {
                nextImage.SetActive(true);
            }
        }

        gameObject.SetActive(false);
    }
}

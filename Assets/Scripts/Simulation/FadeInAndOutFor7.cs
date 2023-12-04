using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class FadeInAndOutFor7 : MonoBehaviour
{
    public float fadeInDuration = 1.0f;  // Time in seconds for the fade in to occur
    public float fadeOutDuration = 1.0f; // Time in seconds for the fade out to occur
    public GameObject nextObject;        // Reference to the next object to activate
    public GameObject nextSlide;         // Reference to the next object to activate

    private Image img;
    private bool fadedOut = false;

    private void Start()
    {
        img = GetComponent<Image>();
        if (img == null)
        {
            Debug.LogError("No Image component found on this GameObject.");
            return;
        }

        // Initially set the image as transparent
        Color c = img.color;
        c.a = 0f;
        img.color = c;

        // Begin the fade in
        StartCoroutine(FadeImage(false));
    }

    private void OnEnable()
    {
        if (!fadedOut)
        {
            StartCoroutine(FadeImage(true));
            fadedOut = true;
        }
    }

    IEnumerator FadeImage(bool fadeAway)
    {
        float targetAlpha = fadeAway ? 0f : 1f;
        float startAlpha = img.color.a;
        float duration = fadeAway ? fadeOutDuration : fadeInDuration;

        for (float t = 0; t < duration; t += Time.deltaTime)
        {
            float normalizedTime = t / duration;
            float alpha = Mathf.Lerp(startAlpha, targetAlpha, normalizedTime);

            Color c = img.color;
            c.a = alpha;
            img.color = c;

            yield return null;
        }

        // Set the final alpha value and handle object activation/deactivation
        Color finalColor = img.color;
        finalColor.a = targetAlpha;
        img.color = finalColor;

        if (fadeAway)
        {
            // Deactivate the image and activate the next objects
            gameObject.SetActive(false);
            if (nextObject != null) nextObject.SetActive(true);
            if (nextSlide != null) nextSlide.SetActive(true);
        }
    }
}

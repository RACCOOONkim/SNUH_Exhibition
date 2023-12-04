using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Renderer))]
public class FadeInOnActivate : MonoBehaviour
{
    private Renderer rend;
    public float fadeDuration = 2.0f; // Duration of the fade-in effect

    private void Awake()
    {
        rend = GetComponent<Renderer>();
        if (rend == null)
        {
            Debug.LogError("No renderer attached to the object!");
            return;
        }

        // Set object to fully transparent initially
        SetAlpha(0f);
    }

    private void OnEnable()
    {
        // Start fading in when object is activated
        StartCoroutine(FadeIn());
    }

    IEnumerator FadeIn()
    {
        float startTime = Time.time;
        float elapsed;

        while ((elapsed = Time.time - startTime) < fadeDuration)
        {
            float alpha = Mathf.Clamp01(elapsed / fadeDuration);
            SetAlpha(alpha);
            yield return null;
        }

        // Ensure it's fully visible after the fade in
        SetAlpha(1f);
    }

    private void SetAlpha(float alpha)
    {
        Color color = rend.material.color;
        color.a = alpha;
        rend.material.color = color;
    }
}

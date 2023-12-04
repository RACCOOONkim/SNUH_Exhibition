using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.EventSystems;
using Oculus.Platform;

public class ImageFadeController : MonoBehaviour
{
    public float fadeDuration = 1.0f; // Time in seconds for the fade to occur
    public GameObject nextObject;     // Reference to the next object to activate
    public GameObject nextSlide;     // Reference to the next object to activate

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

    private void Update()
    {
        // Check if the A button is pressed
        if (OVRInput.GetDown(OVRInput.Button.One))
        {
            if (!fadedOut)
            {
                StartCoroutine(FadeImage(true));
                fadedOut = true;
            }
        }
    }

    IEnumerator FadeImage(bool fadeAway)
    {
        if (fadeAway)
        {
            // Fade out
            for (float i = 1; i >= 0; i -= Time.deltaTime / fadeDuration)
            {
                Color c = img.color;
                c.a = i;
                img.color = c;
                yield return null;
            }

            // Deactivate the image and activate the next object
            gameObject.SetActive(false);
            if (nextObject != null) nextObject.SetActive(true);
            if (nextSlide != null) nextSlide.SetActive(true);
        }
        else
        {
            // Fade in
            for (float i = 0; i <= 1; i += Time.deltaTime / fadeDuration)
            {
                Color c = img.color;
                c.a = i;
                img.color = c;
                yield return null;
            }
        }
    }
}

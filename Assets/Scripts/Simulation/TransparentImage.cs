using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class TransparentImage : MonoBehaviour
{
    public Image imageUI;
    public float fadeDuration = 2.0f;

    private Color initialColor;
    private Color targetColor;
    private float startTime;

    private void Start()
    {
        if (imageUI == null)
        {
            Debug.LogError("Image UI reference not set!");
            enabled = false;
            return;
        }

        initialColor = imageUI.color;
        targetColor = new Color(initialColor.r, initialColor.g, initialColor.b, 0.0f);
        startTime = Time.time;
    }

    private void Update()
    {
        float elapsed = Time.time - startTime;
        float alpha = Mathf.Lerp(initialColor.a, targetColor.a, elapsed / fadeDuration);

        Color newColor = imageUI.color;
        newColor.a = alpha;
        imageUI.color = newColor;

        if (elapsed >= fadeDuration)
        {
            enabled = false; // Disable the script once the fade is complete
        }

        // Your existing Update code here
    }
}

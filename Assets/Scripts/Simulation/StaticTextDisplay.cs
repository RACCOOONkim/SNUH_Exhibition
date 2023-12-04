using UnityEngine;
using TMPro;
using System.Collections;

public class StaticTextDisplay : MonoBehaviour
{
    public float textSpeed = 0.1f; // Time interval at which one character is displayed
    public GameObject handObject; // GameObject containing the following text

    private TextMeshProUGUI textMeshPro;
    private string fullText;
    private string currentText;
    private int index;

    private void Awake()
    {
        textMeshPro = GetComponent<TextMeshProUGUI>();
    }

    private void Start()
    {
        fullText = textMeshPro.text;
        currentText = "";
        index = 0;

        // Execute a coroutine that outputs characters one by one
        StartCoroutine(ShowTextOneByOne());
    }

    private IEnumerator ShowTextOneByOne()
    {
        while (index < fullText.Length)
        {
            currentText = fullText.Substring(0, index + 1);
            textMeshPro.text = currentText;
            index++;

            yield return new WaitForSeconds(textSpeed);
        }

        // After the text is fully displayed, set the handObject to active (true).
        if (handObject != null)
        {
            handObject.SetActive(true);
        }
    }
}

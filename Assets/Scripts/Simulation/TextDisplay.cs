using UnityEngine;
using TMPro;
using System.Collections;

public class TextDisplay : MonoBehaviour
{
    public float textSpeed = 0.1f; // 한 글자가 표시되는 시간 간격
    public GameObject nextTextObject; // 다음 텍스트를 담고 있는 GameObject

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

        // 글자를 한 글자씩 출력하는 코루틴 실행
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

        // 텍스트 출력이 완료되면 다음 텍스트를 활성화하고 현재 텍스트는 비활성화
        if (nextTextObject != null)
        {
            nextTextObject.SetActive(true);
        }

        gameObject.SetActive(false);
    }
}

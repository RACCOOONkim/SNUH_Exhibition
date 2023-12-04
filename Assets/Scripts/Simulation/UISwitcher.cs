using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class UISwitcher : MonoBehaviour
{
    public Image nextImage; 
    public float switchDelay = 10f; 
    public GameObject narrationPanel;
    public float fadeDuration = 3f; // 활성화/비활성화 될 때의 투명도 변경 시간

    private CanvasGroup canvasGroup;

    private void Awake()
    {
        canvasGroup = GetComponent<CanvasGroup>();
        if (!canvasGroup)
        {
            canvasGroup = gameObject.AddComponent<CanvasGroup>();
        }
    }

    private void OnEnable()
    {
        StartCoroutine(FadeCanvasGroup(0f, 1f, fadeDuration)); // 서서히 활성화
        StartCoroutine(SwitchUI());
    }

    private void OnDisable()
    {
        StartCoroutine(FadeCanvasGroup(1f, 0f, fadeDuration)); // 서서히 비활성화
    }

    private IEnumerator SwitchUI()
    {
        yield return new WaitForSeconds(switchDelay + fadeDuration); // fadeDuration을 추가하여 전체 대기 시간을 조정
        gameObject.SetActive(false);

        if (nextImage != null)
        {
            narrationPanel.SetActive(true);
            nextImage.gameObject.SetActive(true);
        }
    }

    private IEnumerator FadeCanvasGroup(float startAlpha, float endAlpha, float duration)
    {
        float elapsedTime = 0f;

        while (elapsedTime < duration)
        {
            float alpha = Mathf.Lerp(startAlpha, endAlpha, elapsedTime / duration);
            canvasGroup.alpha = alpha;

            elapsedTime += Time.deltaTime;
            yield return null;
        }

        canvasGroup.alpha = endAlpha;
    }
}

using UnityEngine;

public class RectTransformAnimation : MonoBehaviour
{
    public RectTransform targetRectTransform;
    public float animationDuration = 10f;

    void Start()
    {
        // 스크립트 시작 시 애니메이션 시작
        StartAnimation();
    }

    void StartAnimation()
    {
        // 코루틴을 사용하여 Pos Y를 0에서 180으로 선형적으로 증가시키는 애니메이션 시작
        StartCoroutine(AnimateYPosition(0f, 180f));
    }

    void UpdateRectTransform(float newYPosition)
    {
        // RectTransform의 Pos Y 업데이트
        Vector2 currentPos = targetRectTransform.anchoredPosition;
        targetRectTransform.anchoredPosition = new Vector2(currentPos.x, newYPosition);
    }

    System.Collections.IEnumerator AnimateYPosition(float startValue, float endValue)
    {
        while (true)
        {
            float elapsedTime = 0f;

            // Pos Y를 0에서 180으로 선형적으로 증가시키는 애니메이션
            while (elapsedTime < animationDuration)
            {
                float newYPosition = Mathf.Lerp(startValue, endValue, elapsedTime / animationDuration);
                UpdateRectTransform(newYPosition);

                elapsedTime += Time.deltaTime;
                yield return null;
            }

            // 180에서 0으로 선형적으로 감소시키는 애니메이션
            elapsedTime = 0f;
            while (elapsedTime < animationDuration)
            {
                float newYPosition = Mathf.Lerp(endValue, startValue, elapsedTime / animationDuration);
                UpdateRectTransform(newYPosition);

                elapsedTime += Time.deltaTime;
                yield return null;
            }
        }
    }
}

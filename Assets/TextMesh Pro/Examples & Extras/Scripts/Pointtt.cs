using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Pointtt : MonoBehaviour
{
    public Image image;
    public Image image1;
    public Image image2;
    public Image image3;
    public Image image4;
    public Image image5;
    public Image image6;

    public float lineWidth = 4f;
    public float drawSpeed = 2f;
    public float delayAfterActivation = 0.5f;
    public float lineWidthScaleFactor = 0.002f;  // 스케일 팩터 추가

    private List<RectTransform> imageRects = new List<RectTransform>();
    private List<GameObject> lines = new List<GameObject>();

    private bool isDrawing = false;

    // Start is called before the first frame update
    void Start()
    {
        imageRects.Add(image.rectTransform);
        imageRects.Add(image1.rectTransform);
        imageRects.Add(image2.rectTransform);
        imageRects.Add(image3.rectTransform);
        imageRects.Add(image4.rectTransform);
        imageRects.Add(image5.rectTransform);
        imageRects.Add(image6.rectTransform);

        // Set all images except the first one as inactive
        for (int i = 1; i < imageRects.Count; i++)
        {
            imageRects[i].gameObject.SetActive(false);
        }

        DrawSequentialLines();
    }

    // Draw sequential lines between images
    void DrawSequentialLines()
    {
        for (int i = 0; i < imageRects.Count - 1; i++)
        {
            GameObject lineObj = new GameObject("Line");
            lineObj.transform.SetParent(transform);

            Image lineImage = lineObj.AddComponent<Image>();
            lineImage.color = new Color(0.7098f, 0.9843f, 1f);

            RectTransform lineRect = lineObj.GetComponent<RectTransform>();

            lineRect.anchorMin = new Vector2(0, 0.5f);
            lineRect.anchorMax = new Vector2(0, 0.5f);
            lineRect.sizeDelta = new Vector2(0, lineWidth * lineWidthScaleFactor);  // 선의 스케일 팩터 적용

            lines.Add(lineObj);
        }

        // 캔버스와 선의 스케일 조절
        transform.localScale = new Vector3(0.002f, 0.002f, 1f);  // 캔버스의 스케일 조절

        StartCoroutine(DrawLinesSequentially());
    }


    // Draw lines sequentially
    IEnumerator DrawLinesSequentially()
    {
        for (int i = 0; i < lines.Count; i++)
        {
            isDrawing = true;

            yield return new WaitForSeconds(drawSpeed);

            StartCoroutine(ActivateImageAfterDelay(imageRects[i + 1]));

            yield return new WaitForSeconds(delayAfterActivation);

            yield return StartCoroutine(DrawLine(lines[i], imageRects[i], imageRects[i + 1]));

            isDrawing = false;
        }
    }

    // Activate the image after a delay
    IEnumerator ActivateImageAfterDelay(RectTransform imageRect)
    {
        yield return new WaitForSeconds(drawSpeed);
        imageRect.gameObject.SetActive(true);
    }

    // Draw a line between two RectTransforms
    IEnumerator DrawLine(GameObject lineObj, RectTransform rectTransform1, RectTransform rectTransform2)
    {
        Vector2 position1 = rectTransform1.position;
        Vector2 position2 = rectTransform2.position;

        Vector2 localPosition1 = rectTransform1.localPosition;
        Vector2 localPosition2 = rectTransform2.localPosition;

        Vector2 dir = (localPosition2 - localPosition1).normalized;
        float distance = Vector2.Distance(localPosition1, localPosition2);

        RectTransform lineRect = lineObj.GetComponent<RectTransform>();

        lineRect.sizeDelta = new Vector2(0, lineWidth * lineWidthScaleFactor);  // 스케일 팩터 적용

        float time = 0f;
        while (time < 1f)
        {
            time += Time.deltaTime / drawSpeed;
            float currentDistance = distance * time;
            lineRect.sizeDelta = new Vector2(currentDistance, lineWidth * lineWidthScaleFactor);  // 스케일 팩터 적용
            lineRect.localPosition = localPosition1 + dir * currentDistance * 0.5f;
            lineRect.localEulerAngles = new Vector3(0, 0, Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg);

            yield return null;
        }
    }
}

using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class ActivateImagesSequentially : MonoBehaviour
{
    public Image[] images;  // Image UI 배열
    public float activationInterval = 2f;

    void Start()
    {
        // 시작 시 모든 이미지를 비활성화
        foreach (var image in images)
        {
            image.gameObject.SetActive(false);
        }

        // 코루틴을 사용하여 이미지를 차례로 활성화
        StartCoroutine(ActivateImages());
    }

    IEnumerator ActivateImages()
    {
        foreach (var image in images)
        {
            // 2초 간격으로 이미지를 활성화
            yield return new WaitForSeconds(activationInterval);

            // 이미지 활성화
            image.gameObject.SetActive(true);
        }
    }
}

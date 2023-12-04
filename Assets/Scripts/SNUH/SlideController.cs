using UnityEngine;
using UnityEngine.UI;

public class SlideController : MonoBehaviour
{
    [SerializeField] private GameObject[] slides; // 슬라이드 오브젝트 배열
    [SerializeField] private Button prevButton, nextButton; // 이전, 다음 버튼

    private int currentSlide = 0; // 현재 슬라이드 번호

    private void Start()
    {
        UpdateSlide();

        prevButton.onClick.AddListener(ShowPrevSlide);
        nextButton.onClick.AddListener(ShowNextSlide);
    }

    public void ShowNextSlide()
    {
        if (currentSlide < slides.Length - 1)
        {
            currentSlide++;
            Debug.Log("Next Slide: " + currentSlide); // 로그 추가
            UpdateSlide();
        }
    }

    public void ShowPrevSlide()
    {
        if (currentSlide > 0)
        {
            currentSlide--;
            Debug.Log("Prev Slide: " + currentSlide); // 로그 추가
            UpdateSlide();
        }
    }

    public void UpdateSlide()
    {
        Debug.Log("Update Slide: " + currentSlide); // 로그 추가
        for (int i = 0; i < slides.Length; i++)
        {
            slides[i].SetActive(i == currentSlide);
        }
    }

}

/*
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TMHillPercent : MonoBehaviour
{
    [Range(0, 100)] // Inspector창에서 no1 값을 0과 100 사이로 조절 가능
    public float no1 = 1; // no1의 초기값을 1로 설정

    public Transform a; // 게임 오브젝트 a 선언

    public TextMeshProUGUI t1; // 텍스트 t1 선언

    void Update()
    {
        UpdatePercent(no1); // 매 프레임마다 UpdatePercent 함수를 no1 값으로 호출
    }

    public void UpdatePercent(float n1)
    {
        float p1 = n1 / 100; // n1을 100으로 나눠 0과 1 사이의 값으로 변환

        a.localScale = new Vector3(1, p1, 1); // 게임 오브젝트 a의 스케일을 변경. Y축 방향을 p1의 값으로 설정

        t1.text = Mathf.Round(p1 * 100).ToString(); // p1 값을 퍼센트로 변환하여 텍스트로 표시
    }
}
*/


using UnityEngine;

public class TMHillPercent : MonoBehaviour
{
    [Range(0, 100)]
    public float no1 = 1;
    public Transform a;

    // 현재 게임 오브젝트의 스케일 값
    private float currentScale = 0;
    // 스케일이 커지는 속도
    public float scaleSpeed = 0.1f;

    void Update()
    {
        // 현재 스케일 값이 no1 값 이하일 때만 스케일을 증가시킵니다.
        if (currentScale < no1)
        {
            currentScale += scaleSpeed;
            a.localScale = new Vector3(1, currentScale / 100, 1);
        }
    }
}

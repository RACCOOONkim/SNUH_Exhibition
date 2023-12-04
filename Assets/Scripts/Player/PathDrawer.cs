using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Serialization;

public class PathDrawer : MonoBehaviour
{
    [SerializeField] private Transform nextSectionTransform; // 이동할 목표 오브젝트
    [SerializeField] private LineRenderer lineRenderer; // Line Renderer 컴포넌트
    [SerializeField] private LineRenderer arrowLineRenderer;
    [SerializeField, Range(0f, 1f)] private float lineOffset = 0.1f; // Line Renderer의 위치 오프셋
    [SerializeField] private GameObject watchButton;
    private NavMeshAgent agent; // 네비게이션 에이전트 컴포넌트
    [SerializeField] private bool isOnPath; //플레이어가 다음 Section으로 이동 중인지 체크
    private Section nextSection;
    [SerializeField] private GameObject inGuideUI;
    
    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        if (isOnPath) DrawPath();
    }

    private void DrawPath()
    {
        var path = new NavMeshPath();

        if (NavMesh.SamplePosition(nextSectionTransform.position, out NavMeshHit hit, 100f, NavMesh.AllAreas))
        {
            //agent.CalculatePath(hit.position, path); // NavMesh 경로 계산
            NavMesh.CalculatePath(transform.position, nextSectionTransform.position, NavMesh.AllAreas, path);
        }
        else
        {
            // 목표 위치가 NavMesh 상에서 접근 불가능한 경우
            lineRenderer.enabled = false;
            arrowLineRenderer.enabled = false;
            return;
        }

        if (path.corners.Length < 2) return; // 경로가 2개 이상의 점을 가지지 않으면 종료

        lineRenderer.enabled = true;
        arrowLineRenderer.enabled = true;
        lineRenderer.positionCount = path.corners.Length; // 경로 점의 개수로 Line Renderer의 점 개수 설정
        arrowLineRenderer.positionCount = path.corners.Length;

        for (int i = 0; i < path.corners.Length; i++)
        {
            // 바닥이 아닌 카메라 밑에서 Line Renderer의 위치 조정
            var linePosition = path.corners[i] + Vector3.up * lineOffset;
            var arrowLinePosition = linePosition + Vector3.up * lineOffset;
            lineRenderer.SetPosition(i, linePosition);
            arrowLineRenderer.SetPosition(i, arrowLinePosition);
        }
    }

    public void SetNextSection(Section section)
    {
        nextSectionTransform = section.pivot;
        nextSection = section;
        StartDrawingPath();
    }

    public void StartDrawingPath()
    {
        watchButton.SetActive(false);
        lineRenderer.enabled = true;
        arrowLineRenderer.enabled = true;
        isOnPath = true;
        nextSection.pivot.gameObject.SetActive(true);
        nextSection.col.SetActive(true);
        inGuideUI.SetActive(true);
    }

    public void StopDrawingPath()
    {
        watchButton.SetActive(true);
        isOnPath = false;
        lineRenderer.enabled = false;
        arrowLineRenderer.enabled = false;
        nextSection.pivot.gameObject.SetActive(false);
        inGuideUI.SetActive(false);
    }

}

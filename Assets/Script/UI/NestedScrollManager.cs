using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class NestedScrollManager : MonoBehaviour, IBeginDragHandler, IEndDragHandler
{
    [SerializeField] Scrollbar scrollbar;
    [SerializeField] Transform contentTr;

    [SerializeField] Slider tabSlider;
    [SerializeField] RectTransform[] BtnRect;
    [SerializeField] RectTransform[] BtnImageRect;

    [SerializeField] float thresholdSpeed = 18f;

    const int SIZE = 5; // Contents의 자식(패널) 개수
    float[] pos = new float[SIZE]; // 각 패널의 Scrollbar value값 저장
    float distance; // pos들 간의 간격

    bool isDrag; // 현재 드래그 중인지 아닌지 확인
    float curPos; // 기존 위치
    float targetPos; // 목표 위치 : Update에서 해당 위치로 서서히 움직임
    int targetIndex; // 목표 인덱스 : targetPos가 바뀔 때 같이 바뀜
    
    void Start()
    {
        distance = 1f / (SIZE - 1);
        for (int i = 0; i < SIZE; ++i) pos[i] = distance * i;
        targetIndex = SIZE / 2;
        targetPos = pos[targetIndex];
    }

    float SetPos()
    {
        for (int i = 0; i < SIZE; ++i)
            if (scrollbar.value < pos[i] + distance * 0.5f && scrollbar.value > pos[i] - distance * 0.5)
            {   // 절반거리를 기준으로 가까운 위치를 반환
                targetIndex = i;
                return pos[i];
            }
        return 0f;
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        isDrag = true;
        curPos = SetPos();
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        isDrag = false;

        targetPos = SetPos();
        // 스크롤뷰 드래그를 멈추면 한 패널만 보이도록 targetPos를 설정
        if (curPos == targetPos)
        {
            if (eventData.delta.x > thresholdSpeed && curPos - distance >= 0)
            {
                --targetIndex;
                targetPos = curPos - distance;
            }
                
            else if (eventData.delta.x < -thresholdSpeed && curPos + distance < 1f)
            {
                ++targetIndex;
                targetPos = curPos + distance;
            }
                
        }

        // 목표가 수직스크롤이고, 옆에서 옮겨왔다면 수직스크롤을 맨 위로 올림
        for (int i = 0; i < SIZE; ++i)
            if (curPos != pos[i] && targetPos == pos[i])
            {
                Transform child = contentTr.GetChild(i);
                if (child.GetComponent<ScrollScript>() != null)
                    child.GetChild(1).GetComponent<Scrollbar>().value = 1;
                break;
            }
    }

    void Update()
    {
        tabSlider.value = scrollbar.value;

        if (!isDrag)
        {
            scrollbar.value = Mathf.Lerp(scrollbar.value, targetPos, 0.1f);

            // 목표 버튼은 크기가 커짐
            for (int i = 0; i < SIZE; ++i) BtnRect[i].sizeDelta = new Vector2(i == targetIndex ? 360 : 180, BtnRect[i].sizeDelta.y);
        }

        if (Time.time < 0.1f) return;

        for (int i = 0; i < SIZE; ++i)
        {
            Vector3 BtnTargetPos = BtnRect[i].anchoredPosition3D;
            Vector3 BtnTargetScale = Vector3.one;
            bool textActive = false;

            if (i == targetIndex)
            {
                BtnTargetPos.y = -23f;
                BtnTargetScale = new Vector3(1.2f, 1.2f, 1);
                textActive = true;
            }

            BtnImageRect[i].anchoredPosition3D = Vector3.Lerp(BtnImageRect[i].anchoredPosition3D, BtnTargetPos, 0.25f);
            BtnImageRect[i].localScale = Vector3.Lerp(BtnImageRect[i].localScale, BtnTargetScale, 0.25f);
            BtnImageRect[i].transform.GetChild(0).gameObject.SetActive(textActive);
        }
    }

    public void TabClick(int n)
    {
        targetIndex = n;
        targetPos = pos[n];
    }
}

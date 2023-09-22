using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ScrollScript : ScrollRect
{
    bool forParent;
    GameObject parentScrollView;
    NestedScrollManager NM;
    ScrollRect parentScrollRect;

    protected override void Start()
    {
        parentScrollView = transform.parent.parent.parent.gameObject;
        NM = parentScrollView.GetComponent<NestedScrollManager>();
        parentScrollRect = parentScrollView.GetComponent<ScrollRect>();
    }

    public override void OnBeginDrag(PointerEventData eventData)
    {
        // 드래그 시작하는 순간 수평이동이 크면 부모가 드래그 시작한 것, 수직이동이 크면 자식이 드래그 시작한 것
        forParent = Mathf.Abs(eventData.delta.x) > Mathf.Abs(eventData.delta.y);

        if (forParent)
        {
            parentScrollRect.OnBeginDrag(eventData);
            NM.OnBeginDrag(eventData);
        }
        else base.OnBeginDrag(eventData);
    }

    public override void OnDrag(PointerEventData eventData)
    {
        if (forParent)
        {
            parentScrollRect.OnDrag(eventData);
        }
        else base.OnDrag(eventData);
    }

    public override void OnEndDrag(PointerEventData eventData)
    {
        if (forParent)
        {
            parentScrollRect.OnEndDrag(eventData);
            NM.OnEndDrag(eventData);
        }
        else base.OnEndDrag(eventData);
    }
}

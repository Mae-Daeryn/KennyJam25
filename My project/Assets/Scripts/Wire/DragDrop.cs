using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragDrop : MonoBehaviour, IPointerDownHandler, IBeginDragHandler, IEndDragHandler, IDragHandler
{

    private RectTransform rectTransform;


    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
    }
    public void OnPointerDown(PointerEventData eventData)
    {
        Debug.Log("test");
    }

    public void OnDrag(PointerEventData eventData)
    {

        Debug.Log("test");
        rectTransform.anchoredPosition += eventData.delta;
    }
    public void OnBeginDrag(PointerEventData eventData)
    {

        Debug.Log("test");
    }
    public void OnEndDrag(PointerEventData eventData)
    {
        Debug.Log("test");

    }
}

using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragDrop : MonoBehaviour, IPointerDownHandler, IBeginDragHandler, IEndDragHandler, IDragHandler
{

    private RectTransform rectTransform;
    [SerializeField] private Canvas canvas;
    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
    }
    public void OnPointerDown(PointerEventData eventData)
    {
    }

    public void OnDrag(PointerEventData eventData)
    {
        rectTransform.anchoredPosition += eventData.delta / canvas.scaleFactor;
    }
    public void OnBeginDrag(PointerEventData eventData)
    {
        GameObject neu = Instantiate(gameObject, transform.parent);
        RectTransform rtOriginal = GetComponent<RectTransform>();
        RectTransform rtNeu = neu.GetComponent<RectTransform>();

        rtNeu.anchoredPosition = rtOriginal.anchoredPosition;
        rtNeu.sizeDelta = rtOriginal.sizeDelta;
        rtNeu.localScale = rtOriginal.localScale;
    }
    public void OnEndDrag(PointerEventData eventData)
    {

    }
}

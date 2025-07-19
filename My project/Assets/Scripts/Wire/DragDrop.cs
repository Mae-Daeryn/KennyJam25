using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DragDrop : MonoBehaviour, IPointerDownHandler, IBeginDragHandler, IEndDragHandler, IDragHandler
{

    private RectTransform rectTransform;
    [SerializeField] private Canvas canvas;
    private CanvasGroup canvasGroup;
    public AudioSource audio;
    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        canvasGroup = GetComponent<CanvasGroup>();
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


        gameObject.transform.localScale = new Vector3(1,1,1);
    }
    public void OnEndDrag(PointerEventData eventData)
    {
        canvasGroup.blocksRaycasts = true;

        List<RaycastResult> results = new List<RaycastResult>();
        EventSystem.current.RaycastAll(eventData, results);

        foreach (RaycastResult result in results)
        {
            GameObject target = result.gameObject;

            if (target.CompareTag("empty"))
            {
                target.GetComponent<Image>().sprite = gameObject.GetComponent<Image>().sprite;
                Destroy(gameObject);
                audio.Play();
                return;
            }
        }

        Destroy(gameObject);
    }
}

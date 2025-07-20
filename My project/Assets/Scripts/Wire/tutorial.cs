using UnityEngine;
using UnityEngine.EventSystems;

public class tutorial : MonoBehaviour, IPointerClickHandler
{

    public GameObject tut;

    public void OnPointerClick(PointerEventData eventData)
    {
        tut.SetActive(false);
    }

}

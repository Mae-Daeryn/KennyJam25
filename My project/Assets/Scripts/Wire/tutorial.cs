using UnityEngine;
using UnityEngine.EventSystems;

public class tutorial : MonoBehaviour, IPointerClickHandler
{

    public GameObject tut;

    public void OnPointerClick(PointerEventData eventData)
    {
        RandomLevel.startTimer = true;
        Debug.Log("Test");
        tut.SetActive(false);

    }


}

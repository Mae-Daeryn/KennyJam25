using UnityEngine;
using UnityEngine.EventSystems;

public class quitgame : MonoBehaviour, IPointerClickHandler
{

    public void OnPointerClick(PointerEventData eventData)
    {
        Application.Quit();
    }

}

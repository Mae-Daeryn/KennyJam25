using UnityEngine;
using UnityEngine.EventSystems;

public class resume : MonoBehaviour, IPointerClickHandler
{

    public GameObject pauseMenuUI;
    public void OnPointerClick(PointerEventData eventData)
    {
        pauseMenuUI.SetActive(false);
        EscapeMenu.isPaused = false;
        RandomLevel.timerIsRunning = true;
    }

}

using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class resume : MonoBehaviour, IPointerClickHandler
{

    public GameObject pauseMenuUI;
    public GameObject slider;
    public void OnPointerClick(PointerEventData eventData)
    {
        pauseMenuUI.SetActive(false);
        EscapeMenu.isPaused = false;
        if (SceneManager.GetActiveScene().name.Equals("Wire_game"))
        {
            RandomLevel.timerIsRunning = true;

        }
        else if (SceneManager.GetActiveScene().name.Equals("CodeCrack_game"))
        {
            ColorCodeGame.timerIsRunning = true;

        }
        volume.currentVolume = slider.GetComponent<Slider>().value;
    }

}

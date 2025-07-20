using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EscapeMenu : MonoBehaviour
{
    public GameObject pauseMenuUI;
    public GameObject slider;
    public static bool isPaused = false;

    void Start()
    {
        pauseMenuUI.SetActive(false);    
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    public void Resume()
    {
        volume.currentVolume = slider.GetComponent<Slider>().value;
        pauseMenuUI.SetActive(false);
        isPaused = false;
        if(SceneManager.GetActiveScene().name.Equals("Wire_game"))
        {
            RandomLevel.timerIsRunning = true;

        }else if (SceneManager.GetActiveScene().name.Equals("CodeCrack_game"))
            {
                ColorCodeGame.timerIsRunning = true;

            }
    }

    public void Pause()
    {
        pauseMenuUI.SetActive(true);
        isPaused = true;
        if (SceneManager.GetActiveScene().name.Equals("Wire_game"))
        {
            RandomLevel.timerIsRunning = false;

        }
        else if (SceneManager.GetActiveScene().name.Equals("CodeCrack_game"))
        {
            ColorCodeGame.timerIsRunning = false;

        }

        slider.GetComponent<Slider>().value = volume.currentVolume;
    }

}

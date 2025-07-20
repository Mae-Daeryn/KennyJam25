using UnityEngine;

public class EscapeMenu : MonoBehaviour
{
    public GameObject pauseMenuUI;
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
        pauseMenuUI.SetActive(false);
        isPaused = false;
        RandomLevel.timerIsRunning = true;
    }

    public void Pause()
    {
        pauseMenuUI.SetActive(true);
        isPaused = true;
        RandomLevel.timerIsRunning = false;
    }

}

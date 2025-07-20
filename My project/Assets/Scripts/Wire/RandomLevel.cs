using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RandomLevel : MonoBehaviour
{

    [SerializeField] public List<GameObject> levels;
    public Texture2D customCursor;
    public Vector2 hotspot = Vector2.zero;
    public CursorMode cursorMode = CursorMode.Auto;

    public GameObject time;
    public GameObject gameover;

    public static Boolean startTimer = false;

    float timeRemaining = 60f;
    public static Boolean timerIsRunning = true;

    public AudioSource timerrunout;

    void Update()
    {
        if (startTimer == true)
        {


            if (timerIsRunning)
            {
                if (timeRemaining > 0)
                {
                    timeRemaining -= Time.deltaTime;
                    time.GetComponent<Text>().text = Mathf.Ceil(timeRemaining).ToString(); ;
                    if(timeRemaining < 10)
                    {
                        timerrunout.Play();
                    }
                }
                else
                {
                    timeRemaining = 0;
                    timerIsRunning = false;
                    gameover.SetActive(true);

                }
            }
        }
    }

    void Start()
    {
        gameover.SetActive(false);
        Cursor.visible = true;

        Cursor.lockState = CursorLockMode.None;
        Cursor.SetCursor(customCursor, hotspot, cursorMode);
        if (current.currentlevel == null)
        {
            foreach (var item in levels)
            {
                item.SetActive(false);
            }

            GameObject randomLevel = levels[UnityEngine.Random.Range(0, levels.Count)];
            randomLevel.SetActive(true);
            current.currentlevel = randomLevel;
        }
        else
        {
            foreach (var item in levels)
            {
                item.SetActive(false);
            }

            current.currentlevel.SetActive(true);
        }

    }

}

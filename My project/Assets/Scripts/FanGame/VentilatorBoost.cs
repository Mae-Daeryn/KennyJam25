using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using System.Collections;
using System;

public class VentilatorBoost : MonoBehaviour
{
    public Button[] fanButtons;
    public TextMeshProUGUI statusText;

    private int[] correctSequence;
    private int currentStep = 0;
    private bool gameActive = true;
    private bool[] isFanOn;
    public Vector2 hotspot = Vector2.zero;
    public UnityEngine.CursorMode cursorMode = UnityEngine.CursorMode.Auto;
    public Texture2D customCursor;
    public GameObject time;
    public GameObject gameover;

    public GameObject wrongsound;
    public GameObject correctsound; 
    public static Boolean startTimer = false;

    float timeRemaining = 60f;
    public static Boolean timerIsRunning = true;

    public AudioSource timerrunout;
    private int lastSecondPlayed = -1;
    public AudioSource gameovermusic;

    void Start()
    {
        gameover.SetActive(false);
        Cursor.visible = true;

        Cursor.lockState = CursorLockMode.None;
        Cursor.SetCursor(customCursor, hotspot, cursorMode);
        isFanOn = new bool[fanButtons.Length];
        correctSequence = GenerateRandomSequence(fanButtons.Length);

        for (int i = 0; i < fanButtons.Length; i++)
        {
            int index = i;
            isFanOn[i] = false;
            fanButtons[i].onClick.AddListener(() => ToggleFan(index));
            SetFanState(index, false);
        }

        statusText.text = "Find the correct fan sequence!";
    }

    void ToggleFan(int index)
    {
        if (!gameActive || !fanButtons[index].interactable)
            return;

        if (index == correctSequence[currentStep])
        {
            SetFanState(index, true);
            currentStep++;

            if (currentStep >= correctSequence.Length)
            {
                gameActive = false;
                StartCoroutine(ShowSuccessAndLoadScene());
            }
            else
            {
                correctsound.GetComponent<AudioSource>().Play();
                statusText.text = $"Step {currentStep}/{fanButtons.Length}";
            }
        }
        else
        {
            ResetFans();
            currentStep = 0;
            wrongsound.GetComponent<AudioSource>().Play();
            statusText.text = "Wrong! Restart the sequence.";
        }
    }

    void SetFanState(int index, bool isOn)
    {
        isFanOn[index] = isOn;
        fanButtons[index].GetComponentInChildren<TextMeshProUGUI>().text = isOn ? "ON" : "OFF";
        fanButtons[index].image.color = isOn ? Color.green : Color.red;
    }

    void ResetFans()
    {
        for (int i = 0; i < fanButtons.Length; i++)
        {
            SetFanState(i, false);
        }
    }

    int[] GenerateRandomSequence(int length)
    {
        List<int> indices = new List<int>();
        for (int i = 0; i < length; i++)
            indices.Add(i);

        for (int i = 0; i < length; i++)
        {
            int rand = UnityEngine.Random.Range(i, length);
            int temp = indices[i];
            indices[i] = indices[rand];
            indices[rand] = temp;
        }

        return indices.ToArray();
    }
    IEnumerator ShowSuccessAndLoadScene()
    {
        correctsound.GetComponent<AudioSource>().Play();
        statusText.text = "Correct sequence! \n Cooling stabilized.";
        timerIsRunning = false;
        yield return new WaitForSeconds(2f);
        current.donevent = true;
        UnityEngine.SceneManagement.SceneManager.LoadScene("kenny");
    }
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
                    int currentSecond = Mathf.FloorToInt(timeRemaining);
                    if (timeRemaining < 10f && currentSecond != lastSecondPlayed)
                    {
                        timerrunout.Play();
                        lastSecondPlayed = currentSecond;
                    }
                }
                else
                {
                    timeRemaining = 0;
                    timerIsRunning = false;
                    gameover.SetActive(true);
                    gameovermusic.Play();

                }
            }
        }
    }
}

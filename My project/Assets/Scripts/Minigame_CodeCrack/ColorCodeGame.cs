using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using static UnityEngine.InputSystem.UI.VirtualMouseInput;
using System;
using UnityEngine.Playables;
using System.Collections;

public class ColorCodeGame : MonoBehaviour
{
    public Sprite[] colorSprites; // [0]=rot, [1]=grün, [2]=blau, [3]=gelb
    public Image[] slotImages;    // Referenzen zu Slot0-3
    public Button confirmButton;
    public Transform feedbackPanel;
    public GameObject feedbackTextPrefab;
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

    private int[] secretCode = new int[4];
    private int[] currentGuess = new int[4];

    void Start()
    {
        gameover.SetActive(false);
        Cursor.visible = true;

        Cursor.lockState = CursorLockMode.None;
        Cursor.SetCursor(customCursor, hotspot, cursorMode);
        GenerateSecretCode();
        confirmButton.onClick.AddListener(CheckGuess);
        UpdateSlots();
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

    void GenerateSecretCode()
    {
        for (int i = 0; i < 4; i++)
            secretCode[i] = UnityEngine.Random.Range(0, colorSprites.Length);
        Debug.Log("Secret Code: " + string.Join(",", secretCode));
    }

    public void CycleSlot(int index)
    {
        currentGuess[index] = (currentGuess[index] + 1) % colorSprites.Length;
        UpdateSlots();
    }

    void UpdateSlots()
    {
        for (int i = 0; i < 4; i++)
            slotImages[i].sprite = colorSprites[currentGuess[i]];
    }

    void CheckGuess()
    {
        string[] feedback = new string[4] { "X", "X", "X", "X" };
        int[] secretColorCounts = new int[colorSprites.Length];
        int[] guessColorCounts = new int[colorSprites.Length];

        // Schritt 1: Zählen wie oft jede Farbe im Secret vorkommt
        for (int i = 0; i < 4; i++)
        {
            secretColorCounts[secretCode[i]]++;
        }

        // Schritt 2: Exakte Übereinstimmungen markieren (O)
        for (int i = 0; i < 4; i++)
        {
            if (currentGuess[i] == secretCode[i])
            {
                feedback[i] = "O";
                secretColorCounts[currentGuess[i]]--;
                guessColorCounts[currentGuess[i]]++;
            }
        }

        // Schritt 3: Farben am falschen Platz erkennen (?)
        for (int i = 0; i < 4; i++)
        {
            if (feedback[i] != "X") continue;

            int color = currentGuess[i];
            if (secretColorCounts[color] > 0)
            {
                feedback[i] = "?";
                secretColorCounts[color]--;
                guessColorCounts[color]++;
            }
        }

        // Feedback anzeigen
        GameObject feedbackObj = Instantiate(feedbackTextPrefab, feedbackPanel);
        feedbackObj.GetComponent<TMPro.TextMeshProUGUI>().text = string.Join(" ", feedback);

        int maxFeedback = 2;
        int toRemove = feedbackPanel.childCount - maxFeedback;
        for (int i = 0; i < toRemove; i++)
        {
            Destroy(feedbackPanel.GetChild(i).gameObject);
        }



        if (string.Join(" ", feedback) == "O O O O")
        {
            correctsound.GetComponent<AudioSource>().Play();
            timerIsRunning = false;
                current.doneCodeCrack = true;
                SceneManager.LoadScene("kenny");
        }
        else
        {
            wrongsound.GetComponent<AudioSource>().Play();
        }
    }

}
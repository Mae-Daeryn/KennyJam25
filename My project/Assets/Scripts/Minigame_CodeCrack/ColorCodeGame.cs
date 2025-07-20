using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ColorCodeGame : MonoBehaviour
{
    public Sprite[] colorSprites; // [0]=rot, [1]=grün, [2]=blau, [3]=gelb
    public Image[] slotImages;    // Referenzen zu Slot0-3
    public Button confirmButton;
    public Transform feedbackPanel;
    public GameObject feedbackTextPrefab;

    private int[] secretCode = new int[4];
    private int[] currentGuess = new int[4];

    void Start()
    {
        GenerateSecretCode();
        confirmButton.onClick.AddListener(CheckGuess);
        UpdateSlots();
    }

    void GenerateSecretCode()
    {
        for (int i = 0; i < 4; i++)
            secretCode[i] = Random.Range(0, colorSprites.Length);
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
        for (int i = 0;i < toRemove;i++)
        {
            Destroy(feedbackPanel.GetChild(i).gameObject);
        }


        
        if (string.Join(" ", feedback) == "O O O O")
        {
            Debug.Log("Zugang gewährt!");
            SceneManager.LoadScene("kenny");
        }
    }

}

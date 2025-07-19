using UnityEngine;
using UnityEngine.UI;

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
        string result = "";
        bool[] usedSecret = new bool[4];
        bool[] usedGuess = new bool[4];

        for (int i = 0; i < 4; i++)
        {
            if (currentGuess[i] == secretCode[i])
            {
                result += "🟩 ";
                usedSecret[i] = true;
                usedGuess[i] = true;
            }
        }

        for (int i = 0; i < 4; i++)
        {
            if (usedGuess[i]) continue;

            for (int j = 0; j < 4; j++)
            {
                if (!usedSecret[j] && currentGuess[i] == secretCode[j])
                {
                    result += "🟨 ";
                    usedSecret[j] = true;
                    break;
                }
            }
        }

        while (result.Split(' ').Length - 1 < 4)
            result += "❌ ";

        GameObject feedback = Instantiate(feedbackTextPrefab, feedbackPanel);
        feedback.GetComponent<TMPro.TextMeshProUGUI>().text = result.Trim();

        if (result.Trim() == "🟩 🟩 🟩 🟩")
        {
            Debug.Log("Zugang gewährt!");
        }
    }
}

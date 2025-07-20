using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using System.Collections;

public class VentilatorBoost : MonoBehaviour
{
    public Button[] fanButtons;
    public TextMeshProUGUI statusText;

    private int[] correctSequence;
    private int currentStep = 0;
    private bool gameActive = true;
    private bool[] isFanOn;

    void Start()
    {
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
                statusText.text = $"Step {currentStep}/{fanButtons.Length}";
            }
        }
        else
        {
            ResetFans();
            currentStep = 0;
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
            int rand = Random.Range(i, length);
            int temp = indices[i];
            indices[i] = indices[rand];
            indices[rand] = temp;
        }

        return indices.ToArray();
    }
    IEnumerator ShowSuccessAndLoadScene()
    {
        statusText.text = "Correct sequence! Cooling stabilized.";
        yield return new WaitForSeconds(2f);
        UnityEngine.SceneManagement.SceneManager.LoadScene("kenny");
    }

}

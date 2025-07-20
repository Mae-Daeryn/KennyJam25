using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SignalStabilizer : MonoBehaviour
{
    public TextMeshProUGUI signalText;
    public Button plusButton;
    public Button minusButton;
    public GameObject successPanel;

    private float signal = 0f;
    private float targetSignal = 50f;
    private float maxDrift = 1.5f;
    private float correctionAmount = 1f;
    private float successThreshold = 3f;
    private float stableTime = 0f;
    private float requiredStableTime = 3f;
    private bool isGameActive = true;

    void Start()
    {
        plusButton.onClick.AddListener(() => AdjustSignal(correctionAmount));
        minusButton.onClick.AddListener(() => AdjustSignal(-correctionAmount));
        successPanel.SetActive(false);
    }

    void Update()
    {
        if (!isGameActive) return;

        // Drift
        signal += Random.Range(-maxDrift, maxDrift) * Time.deltaTime * 10f;
        signal = Mathf.Clamp(signal, 0f, 100f);

        signalText.text = "Signal: " + Mathf.RoundToInt(signal).ToString();

        // Check if within threshold
        if (Mathf.Abs(signal - targetSignal) <= successThreshold)
        {
            stableTime += Time.deltaTime;
            if (stableTime >= requiredStableTime)
            {
                GameSuccess();
            }
        }
        else
        {
            stableTime = 0f;
        }
    }

    void AdjustSignal(float amount)
    {
        signal += amount;
        signal = Mathf.Clamp(signal, 0f, 100f);
    }

    void GameSuccess()
    {
        isGameActive = false;
        successPanel.SetActive(true);
        Debug.Log("Signal stablized!");
    }
}

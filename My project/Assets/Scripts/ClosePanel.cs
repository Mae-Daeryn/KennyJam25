using UnityEngine;

public class ClosePanel : MonoBehaviour
{
    public GameObject panelClose;

    public void CloseThePanel()
    {
        ColorCodeGame.startTimer = true;
        Debug.Log("test");
        panelClose.SetActive(false);
    }
}

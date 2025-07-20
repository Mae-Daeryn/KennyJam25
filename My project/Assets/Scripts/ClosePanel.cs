using UnityEngine;

public class ClosePanel : MonoBehaviour
{
    public GameObject panelClose;

    public void CloseThePanel()
    {
        panelClose.SetActive(false);
    }
}

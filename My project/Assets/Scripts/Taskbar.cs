using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Taskbar : MonoBehaviour
{

    public GameObject checkbox1;
    public GameObject checkbox2;
    public TextMeshPro task1;
    public TextMeshPro task2;

    void Start()
    {
        if(current.done == true)
        {
            task1.fontStyle = FontStyles.Strikethrough;
            checkbox1.GetComponent<Image>().color = Color.green;
        }
    }
}

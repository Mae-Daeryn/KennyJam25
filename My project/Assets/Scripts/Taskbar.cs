using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Taskbar : MonoBehaviour
{

    public GameObject checkbox1;
    public GameObject checkbox2;
    public GameObject task1;
    public GameObject task2;

    void Start()
    {
        if(current.done == true)
        {
            task1.GetComponent<TextMeshProUGUI>().text = "<s>" + task1.GetComponent<TextMeshProUGUI>().text + "</s>";
            checkbox1.GetComponent<Image>().color = Color.green;
        }
        if (current.doneCodeCrack == true)
        {
            task2.GetComponent<TextMeshProUGUI>().text = "<s>" + task2.GetComponent<TextMeshProUGUI>().text + "</s>";
            checkbox2.GetComponent<Image>().color = Color.green;
        }
    }
}

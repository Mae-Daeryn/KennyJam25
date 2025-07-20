using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Taskbar : MonoBehaviour
{

    public GameObject checkbox1;
    public GameObject checkbox2;
    public GameObject task1;
    public GameObject task2;
    public GameObject checkbox3;
    public GameObject task3;

    public GameObject levelSuccess;

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
        if (current.donevent == true)
        {
            task3.GetComponent<TextMeshProUGUI>().text = "<s>" + task3.GetComponent<TextMeshProUGUI>().text + "</s>";
            checkbox3.GetComponent<Image>().color = Color.green;
        }

        if (current.donevent == true && current.doneCodeCrack == true && current.done == true)
        {
            levelSuccess.SetActive(true);
        }
        else
        {
            levelSuccess.SetActive(false);
        }
    }
}

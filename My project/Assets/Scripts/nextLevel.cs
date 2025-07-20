using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class nextLevel : MonoBehaviour, IPointerClickHandler
{

    public GameObject next;
    public static bool isnext;
    public GameObject checkbox1;
    public GameObject checkbox2;
    public GameObject task1;
    public GameObject task2;
    public GameObject checkbox3;
    public GameObject task3;

    void Start()
    {
        
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        current.gamelevel += 1;
        current.done = false;
        current.doneCodeCrack = false;
        current.donevent = false;
        EscapeMenu.isPaused = false;
        isnext = false;
        next.SetActive(false);

        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        task1.GetComponent<TextMeshProUGUI>().text = "restore the circuit on the computer";
        checkbox1.GetComponent<Image>().color = Color.white;
        task2.GetComponent<TextMeshProUGUI>().text = "crack the color code at the terminal";
        checkbox2.GetComponent<Image>().color = Color.white;
        task3.GetComponent<TextMeshProUGUI>().text = "Fix the ventilation system at the vent";
        checkbox3.GetComponent<Image>().color = Color.white;
    }

    void Update()
    {
        
    }
}

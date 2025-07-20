using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class tutorial : MonoBehaviour, IPointerClickHandler
{

    public GameObject tut;

    public void OnPointerClick(PointerEventData eventData)
    {
        if(SceneManager.GetActiveScene().name.Equals("Ventilator_game"))
        {

            VentilatorBoost.startTimer = true;
            tut.SetActive(false);
        }
        if (SceneManager.GetActiveScene().name.Equals("Wire_game"))
        {
            RandomLevel.startTimer = true;
            tut.SetActive(false);
        }

    }


}

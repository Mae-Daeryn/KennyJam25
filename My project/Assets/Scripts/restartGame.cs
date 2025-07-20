using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class restartGame : MonoBehaviour, IPointerClickHandler
{


    public void OnPointerClick(PointerEventData eventData)
    {
        current.done = false;
        current.currentlevel = null;
        current.gamelevel = 1;

        SceneManager.LoadScene("kenny");
    }

}

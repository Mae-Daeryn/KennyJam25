using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class exitbutton : MonoBehaviour, IPointerClickHandler
{

    public void OnPointerClick(PointerEventData eventData)
    {
        SceneManager.LoadScene(sceneBuildIndex: 1);
    }
    
}

using UnityEngine;

public class moveCamera : MonoBehaviour
{

    public Transform cameraPosition;

    void Update()
    {
        if(!EscapeMenu.isPaused) { 
        transform.position = cameraPosition.position;
        transform.rotation = cameraPosition.rotation;
        }
    }
}

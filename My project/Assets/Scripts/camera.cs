using UnityEngine.EventSystems;
using UnityEngine;
using Unity.VisualScripting;
using JetBrains.Annotations;

public class CameraToggle : MonoBehaviour {

    public GameObject cam;

    void Update()
    {
        cam.transform.position = transform.position;

    }

}
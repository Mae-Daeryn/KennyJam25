using UnityEngine;

public class detectBox : MonoBehaviour
{

    public GameObject interactText;

    private void Start()
    {
        interactText.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            interactText.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            interactText.SetActive(false);
        }
    }
}
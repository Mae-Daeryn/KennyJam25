using UnityEngine;
using UnityEngine.SceneManagement;

public class detectBoxTaskVent : MonoBehaviour
{

    public GameObject interactText;
    private bool playerInside = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (current.donevent == false)
            {
                playerInside = true;
                interactText.SetActive(true);
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInside = false;
            interactText.SetActive(false);
        }
    }

    private void Update()
    {
        if (playerInside && !current.donevent && Input.GetKeyDown(KeyCode.E))
        {
            SceneManager.LoadScene("Ventilator_game");
        }
    }
}
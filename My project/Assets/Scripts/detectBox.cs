using UnityEngine;
using UnityEngine.SceneManagement;

public class detectBox : MonoBehaviour
{

    public GameObject interactText;
    private bool playerInside = false;

    private void Start()
    {
        interactText.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Test");
            if (current.done == false)
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
        if (playerInside && !current.done && Input.GetKeyDown(KeyCode.E))
        {
            SceneManager.LoadScene("Wire_game");
        }
    }
}
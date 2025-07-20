using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class checkPuzzle : MonoBehaviour, IPointerClickHandler

{
    public AudioSource wrong;
    public AudioSource correct_sound;
    public List<Sprite> options;
    public GameObject notification;
    public GameObject correct_text;
    public GameObject wrong_text;

    void Start()
    {
        notification.SetActive(false);
        correct_text.SetActive(false);
        wrong_text.SetActive(false);
    }


    public void OnPointerClick(PointerEventData eventData)
    {
        Level level = current.currentlevel.GetComponent<Level>();
        int correct = 0;
        foreach (TileOption tile in level.tileOptions)
        {
            if (tile.panel == null || tile.options == null) continue;

            foreach (string strIndex in tile.options)
            {
                if (!int.TryParse(strIndex, out int num)) continue;

                int spriteIndex = num - 1;

                if (spriteIndex < 0 || spriteIndex >= options.Count) continue;

                Sprite expectedSprite = options[spriteIndex];

                Image img = tile.panel.GetComponent<Image>();
                if (img == null)
                {
                    continue;
                }
                if (img.sprite == expectedSprite)
                {
                    correct += 1;
                }
            }

        }
    
        if(correct == level.tileOptions.Count)
        {
            correct_sound.Play();
            StartCoroutine(waitCorrect());

        }
        else
        {
            wrong.Play();
            StartCoroutine(waitWrong());
        }
    }
    IEnumerator waitWrong()
    {
        notification.SetActive(true);
        wrong_text.SetActive(true);
        yield return new WaitForSeconds(2);
        wrong_text.SetActive(false);
        notification.SetActive(false);
    }
    IEnumerator waitCorrect()
    {
        notification.SetActive(true);
        correct_text.SetActive(true);
        RandomLevel.startTimer = false;
        yield return new WaitForSeconds(2);
        correct_text.SetActive(false);
        notification.SetActive(false);
        SceneManager.LoadScene(sceneBuildIndex: 1);
        current.currentlevel = null;
        current.done = true;
    }

}

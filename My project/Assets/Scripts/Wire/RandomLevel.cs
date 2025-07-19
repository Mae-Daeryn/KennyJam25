using System.Collections.Generic;
using UnityEngine;

public class RandomLevel : MonoBehaviour
{

    [SerializeField] public List<GameObject> levels;

    void Start()
    {
        foreach (var item in levels)
        {
            item.SetActive(false);
        }

        GameObject randomLevel = levels[Random.Range(0, levels.Count)];
        randomLevel.SetActive(true);

    }
}

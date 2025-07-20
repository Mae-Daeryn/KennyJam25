using UnityEngine;

public class setVolume : MonoBehaviour
{
    void Start()
    {
        gameObject.GetComponent<AudioSource>().volume = volume.currentVolume;
    }

    void Update()
    {
        gameObject.GetComponent<AudioSource>().volume = volume.currentVolume;
    }
}

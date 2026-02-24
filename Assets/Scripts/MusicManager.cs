using UnityEngine;

public class MusicManager : MonoBehaviour
{
    private AudioSource audioSource;

    void OnEnable()
    {
        GameManager.OnGameOver += StopMusic;
    }

    void OnDisable()
    {
        GameManager.OnGameOver -= StopMusic;
    }

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void StopMusic()
    {
        audioSource.Stop();
    }
}
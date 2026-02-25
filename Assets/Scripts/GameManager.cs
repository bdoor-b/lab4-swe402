using UnityEngine;
using System;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public static event Action OnGameOver;
    private bool gameOver = false;
    private int score = 0;

    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private TextMeshProUGUI waveText;
    [SerializeField] private GameObject gameOverText;
    [SerializeField] private GameObject restartButton;
    [SerializeField] private GameObject titleScreen;


    // Update is called once per frame
    void Update()
    {
        GameObject player = GameObject.FindWithTag("Player");
        if (player != null && player.transform.position.y < -10 && !gameOver)
        {
            gameOver = true;
            OnGameOver?.Invoke();
            gameOverText.SetActive(true);
            restartButton.SetActive(true);
            titleScreen.SetActive(false);
        }
    }
}

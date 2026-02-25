using UnityEngine;
using System;
using TMPro;
using UnityEngine.SceneManagement;
using System.Collections;


public class GameManager : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public static event Action OnGameOver;
    public static GameManager Instance;

    private bool isGameActive;
    private int score = 0;

    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private TextMeshProUGUI waveText;
    [SerializeField] private GameObject gameOverText;
    [SerializeField] private GameObject restartButton;
    [SerializeField] private GameObject titleScreen;
    private CanvasGroup gameOverCanvasGroup;


    // Update is called once per frame
    void Start()
    {
        gameOverCanvasGroup = gameOverText.GetComponent<CanvasGroup>();

    
    }

    public void StartGame(int difficulty)
    {
        score = 0;
        isGameActive = true;
        CanvasGroup titleCG = titleScreen.GetComponent<CanvasGroup>();
        StartCoroutine(FadeOut(titleCG, 0.4f));
        GameObject.Find("SpawnManager").GetComponent<SpawnManager>().BeginGame(difficulty);
    }
        

    public void UpdateScore(int points)
    {
        if (isGameActive) 
        {
            score += points;
            scoreText.text = "Score: " + score;
        }
    }
    public void UpdateWaveUI(int waveNumber)
    {
        waveText.text = "Wave: " + waveNumber; 
    }
    public void GameOver()
    {
        isGameActive = false; 
        StartCoroutine(FadeIn(gameOverCanvasGroup, 0.5f));
        gameOverText.SetActive(true);
        restartButton.SetActive(true);
        OnGameOver?.Invoke(); 
    }
       IEnumerator FadeIn(CanvasGroup cg, float duration)
    {
        float t = 0;

        while (t < duration)
        {
            t += Time.deltaTime;         
            cg.alpha = t / duration;     
            yield return null;           
        }

        cg.alpha = 1f; 
        restartButton.SetActive(true); 
    }
    IEnumerator FadeOut(CanvasGroup cg, float duration)
    {
        float t = 0;

        while (t < duration)
        {
            t += Time.deltaTime;
            cg.alpha = 1 - (t / duration); 
            yield return null;
        }

        cg.alpha = 0f;
        titleScreen.SetActive(false); 
    }
    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); 
    }
   
    public bool IsGameActive() => isGameActive;
}

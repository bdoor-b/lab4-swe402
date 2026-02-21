using UnityEngine;
using System;

public class GameManager : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public static event Action OnGameOver;
    private bool gameOver = false;


    // Update is called once per frame
    void Update()
    {
        GameObject player = GameObject.FindWithTag("Player");
        if (player != null && player.transform.position.y < -5 && !gameOver)
        {
            gameOver = true;
            OnGameOver?.Invoke();
            Debug.Log("Game Over!");
        }
    }
}

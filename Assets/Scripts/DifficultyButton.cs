using System;
using UnityEngine;
using UnityEngine.UI;

public class DifficultyButton : MonoBehaviour
{
    private GameManager gameManager;

    [Range(1, 3)]
    [Tooltip("The difficulty level for the game. 1 = Easy, 2 = Medium, 3 = Hard.")]
    [SerializeField] private int difficulty; 

    void Start()
    {
       
    gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        
      GetComponent<Button>().onClick.AddListener(SetDifficulty); 
    }

    void SetDifficulty()
    {
        gameManager.StartGame(difficulty);
    }
}
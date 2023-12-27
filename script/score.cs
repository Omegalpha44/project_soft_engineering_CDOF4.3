using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.ComponentModel;

public class Score : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI timerText;
    public TextMeshProUGUI syntaxText;
    public GameObject coinPrefab;
    public Transform character;
    public GameObject characterObject;

    private static int score;
    private static float timer;

    private void Start()
    {
        score = 0;
        timer = 0f;
        scoreText.text = "Score: " + score.ToString();
        syntaxText.enabled = false;    
    }

    private void Update()
    {
        timer += Time.deltaTime;
        timerText.text = "Time: " + timer.ToString("F2");
        scoreText.text = "Score: " + score.ToString();
    }

    
    public static void IncreaseScore(int amount) // increase score by amount
    {
        score += amount;
    }
    public static int GetScore() // get score
    {
        return score;
    }
    public static float GetTimer()  // get timer
    {
        return timer;
    }
    public static void ResetScore() 
    /// reset score and timer
    {
        score = 0;
        timer = 0f;
    }
}

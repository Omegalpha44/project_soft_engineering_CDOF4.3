using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class pauseSystem : MonoBehaviour
{

    // Start is called before the first frame update

    // the boolean are used in the observer pattern to pause the game, end the game, or fail the game
    bool isPaused = false;
    public static bool isGameFinished = false;
    public static bool isGameFailed = false;
    public TextMeshProUGUI syntaxtext;
    public Transform character;
    void Start()
    {
        syntaxtext.enabled = false;
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
            {
                Time.timeScale = 1f; // Resume game
                isPaused = false;
                syntaxtext.enabled = false;
            }
            else
            {
                Time.timeScale = 0f; // Pause game
                isPaused = true;
                syntaxtext.enabled = true;
                syntaxtext.text = "Press ESC to resume, F1 to exit";
            }
        }
        if(Input.GetKeyDown(KeyCode.F1))
        {
            if(isGameFinished || isGameFailed)
            {
                Application.Quit();
                print("Game exited");
            }
            
        }
        if(isGameFinished)
        {
            Time.timeScale = 0f;
            syntaxtext.enabled = true;
            int score = Score.GetScore();
            
            syntaxtext.text = "Game finished, press F1 to exit \n Your score is: " + score.ToString() + "\n Your time is: " + Score.GetTimer().ToString("F2") + " seconds";
        }
        if(isGameFailed)
        {
            Time.timeScale = 0f;
            syntaxtext.enabled = true;
            syntaxtext.text = "Game failed, press F1 to exit, or ESC to restart";
        }
        if(isGameFailed && Input.GetKeyDown(KeyCode.Escape))
        {
            isGameFailed = false;
            Time.timeScale = 1f;
            syntaxtext.enabled = false;
            Score.ResetScore();
            character.position = new Vector3(-5.8f, 0.6f, 0f);
        }
    }
}

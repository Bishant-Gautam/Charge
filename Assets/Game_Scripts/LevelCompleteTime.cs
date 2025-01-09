using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class LevelCompleteTime : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI levelTimer;
    [SerializeField] TextMeshProUGUI highScore;
    float lTime;
    [SerializeField] GameObject levelCompleteUI;
    float t;
    // Start is called before the first frame update
    void Start()
    {
        highScore.text = PlayerPrefs.GetFloat("HighScore").ToString("f2");
        lTime = Time.time;
    }
    private void Update()
    {
        //This condition is made to execute when the next level UI pops up and display the time taken to complete the game.

        if (levelCompleteUI.activeInHierarchy == true)
        {
            StopLevelTimer();
        }
        else
        {
            StartLevelTimer();
        }
        
    }
    //This method is made to start the time once the level starts
    public void StartLevelTimer()
    {
        t = Time.time - lTime;
        string minutes = ((int)t / 60).ToString();
        string seconds = (t % 60).ToString("f2");

        levelTimer.text = minutes + ":" + seconds;
    }
    //This method is executed when the time stops and save the high score as per the condition 
    public void StopLevelTimer()
    {
        if (PlayerPrefs.GetInt("HighScore") > t)
        {
            PlayerPrefs.SetFloat("HighScore", t);
            highScore.text = t.ToString();
        }
    }
}
    

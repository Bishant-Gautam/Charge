using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//This class is used to change between different scene by pressing buttons
public class NextScene : MonoBehaviour
{
    private int nextScene;
    [SerializeField] AudioSource levelComplete;
    public void ToNextScene()
    {
        levelComplete.Play();
        nextScene = SceneManager.GetActiveScene().buildIndex + 1;
        Time.timeScale = 1f;
        SceneManager.LoadScene(nextScene);
        
    }
    public void Retry()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void StartGame()
    {
        Time.timeScale = 1f; ;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public void ReplayGame()
    {
        Time.timeScale = 1f; ;
        SceneManager.LoadScene("Level_1");
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//This class is made to resume the game after pause and quit the application
public class Settings : MonoBehaviour
{
    public static bool GameIsPaused = false;
    [SerializeField] GameObject pauseUI;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GameIsPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
        
    }
    public void Resume()
    {
        pauseUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }
    public void Pause()
    {
        pauseUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }
    public void HomeScene(string home)
    {
        SceneManager.LoadScene(home);
    }
    public void QuitGame()
    {
        Application.Quit();
    }
}

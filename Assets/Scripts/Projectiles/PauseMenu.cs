using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool gameIsPaused = false;

    public GameObject pauseMenuUI;

    // Update is called once per frame
    void Update()
    {
        //This will know when the esc kay is pressed
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            //this will check whether the boolean gameIsPaused is true or not
            if (gameIsPaused)
            {
                resumeGame();
            }
            else
            {
                PauseGame();
            }
        }
    }
    //this will resume the game when is called
    void resumeGame()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        gameIsPaused = false;
    }
    //This will pause the game when is called
    void PauseGame()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        gameIsPaused = true;
    }
    //this will resume the game when is called
    public void ResumeButton()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        gameIsPaused = false;
    }
    //this will show the credits :)
    public void ShowCredits()
    {

    }
    public void ReturnMenu()
    {
        ResumeButton();
        SceneManager.LoadScene(0);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour

{
    public GameObject settingsMenuUI;
    public GameObject MainMenuUI;

    public void SettingsPanelOn()
    {
        MainMenuUI.SetActive(false);
        settingsMenuUI.SetActive(true);
    }
    public void SettingsPanelOff()
    {
        
        settingsMenuUI.SetActive(false);
        MainMenuUI.SetActive(true);
    }
    public void GoToIntro()
    {
        SceneManager.LoadScene(1);
    }
    public void PlayGame()
    {
        SceneManager.LoadScene(2);
    }

    public void QuitGame()
    {
        Debug.Log("QUIT!");
        Application.Quit();
    }
}

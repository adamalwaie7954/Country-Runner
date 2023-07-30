using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class pausemenu : MonoBehaviour
{
    public static bool GameIsPaused = false;
    public GameObject pauseMenuUI;
    public GameObject pausebutton;

    public void pauseGame()
    {
        if(GameIsPaused)
        {
            Resume();
        }
        else
        {
            pauseMenuUI.SetActive(true);
            pausebutton.SetActive(false);
            GameIsPaused = true;
            Time.timeScale = 0f;
        }

    }

    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        pausebutton.SetActive(true);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }

    public void Exit()
    {
        scenemanager.Instance.MainMenu();
        Time.timeScale = 1f;
        GameIsPaused = false;
        pauseMenuUI.SetActive(false);
    }
}

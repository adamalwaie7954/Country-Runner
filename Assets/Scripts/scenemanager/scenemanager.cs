using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class scenemanager : MonoBehaviour
{
    //public bool adrianStinky;
    
    public static scenemanager Instance;
    // Start is called before the first frame update
    private void Awake()
    {
        Instance = this;
    }

    public enum Scene
    {
        mainmenu,
        collectables,
        settings,
        Malaysia,
        Egypt,
        Japan,
    }

    public void MainMenu()
    {
        SceneManager.LoadScene(Scene.mainmenu.ToString());
    }

    public void Collectables()
    {
        SceneManager.LoadScene(Scene.collectables.ToString());
    }

    public void Malaysia()
    {
        SceneManager.LoadScene(Scene.Malaysia.ToString());
    }

    public void Egypt()
    {
        SceneManager.LoadScene(Scene.Egypt.ToString());
    }

    public void Japan()
    {
        SceneManager.LoadScene(Scene.Japan.ToString());
    }

    public void settings()
    {
        SceneManager.LoadScene(Scene.settings.ToString());
    }
    public void Exit()
    {
        Application.Quit();
        Debug.Log("Exit");
    }

    
}

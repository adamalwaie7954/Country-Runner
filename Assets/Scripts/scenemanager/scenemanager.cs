using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class scenemanager : MonoBehaviour
{
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
        levelselection,
        settings,
        Malaysia,
        Egypt,
        Japan,
        Italy,
        UK
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

    /*    public void level2()
        {
            SceneManager.LoadScene(Scene.level1.ToString());
        }

        public void level3()
        {
            SceneManager.LoadScene(Scene.level3.ToString());
        }

        public void level4()
        {
            SceneManager.LoadScene(Scene.level4.ToString());
        }

        public void level5()
        {
            SceneManager.LoadScene(Scene.level5.ToString());
        }*/

    public void NextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void levelselection()
    {
        SceneManager.LoadScene(Scene.levelselection.ToString());
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

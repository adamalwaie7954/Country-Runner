using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UImainmenu : MonoBehaviour
{
    [SerializeField] Button play;
    [SerializeField] Button settings;
    [SerializeField] Button quit;
    public AudioSource music;
    // Start is called before the first frame update
    void Start()
    {
        play.onClick.AddListener(startplay);
        settings.onClick.AddListener(startsettings);
        quit.onClick.AddListener(startquit);
    }

    private void startplay()
    {
        scenemanager.Instance.Malaysia();
        music.Stop();
    }

    private void startsettings()
    {
        scenemanager.Instance.settings();
    }
    private void startquit()
    {
        scenemanager.Instance.Exit();
    }
}

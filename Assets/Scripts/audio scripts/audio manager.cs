using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class audiomanager : MonoBehaviour
{
    [SerializeField] private AudioMixer myMixer;
    [SerializeField] private Slider musicslider;
    [SerializeField] private Slider sfxslider;
    public AudioSource sfxsound;

    private void Start()
    {
        if(PlayerPrefs.HasKey("music") && musicslider.value < 1)
        {
            LoadVolume();
        }
        else
        {
            SetMusicVolume();
            SetSfxVolume();
        }
        
    }
    public void SetMusicVolume()
    {
        float volume = musicslider.value;
        myMixer.SetFloat("music", (Mathf.Log10(volume)*20) - 3);
        PlayerPrefs.SetFloat("music", volume);
    }

    public void SetSfxVolume()
    {
        float volume = sfxslider.value;
        myMixer.SetFloat("sfx", (Mathf.Log10(volume) * 20)+ 6);
        PlayerPrefs.SetFloat("sfx", volume);
    }

    private void LoadVolume()
    {
        musicslider.value = PlayerPrefs.GetFloat("music");
        sfxslider.value = PlayerPrefs.GetFloat("sfx");
        SetMusicVolume();
        SetSfxVolume();
    }
}

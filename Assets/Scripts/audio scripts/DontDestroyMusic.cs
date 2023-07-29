using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class DontDestroyMusic : MonoBehaviour
{
    private void Awake()
    {
        GameObject[] musicobj = GameObject.FindGameObjectsWithTag("music");
        if(musicobj.Length > 1) 
        {
            Destroy(this.gameObject);
        }
        DontDestroyOnLoad(this.gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

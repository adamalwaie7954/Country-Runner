using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camerascroller : MonoBehaviour
{
    public float Camerascrollspeed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!pausemenu.GameIsPaused)
        {
            transform.Translate(Camerascrollspeed, 0f, 0f);
        }
    }
}

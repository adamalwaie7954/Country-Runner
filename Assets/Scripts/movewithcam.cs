using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class movewithcam : MonoBehaviour
{
    public GameObject go;
    public GameObject spawn1;
    public GameObject bg;
    void LateUpdate()
    {
        //attach Game Object go to target
        Transform target = Camera.main.transform;
        go.transform.parent = target;
        spawn1.transform.parent = target;
        bg.transform.parent = target;
    }
}

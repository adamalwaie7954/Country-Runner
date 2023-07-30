using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class movewithcam : MonoBehaviour
{
    public GameObject go;
    void LateUpdate()
    {
        //attach Game Object go to target
        Transform target = Camera.main.transform;
        go.transform.parent = target;
    }
}

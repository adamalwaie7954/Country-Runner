using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Runtime.Serialization;

public class numberofcollectables : MonoBehaviour
{
    public TextMeshProUGUI numofCollect;
    // Start is called before the first frame update
    void Start()
    {
        /*if(PlayerMovement.collection <= 5)
        {
            if (PlayerPrefs.HasKey("numcollect"))
            {
                Debug.Log("collected");
                LoadCollect();
            }
            else
            {
                PlayerPrefs.SetInt("numcollect", PlayerMovement.collection);
                numofCollect.text = PlayerMovement.collection + "/5";
            }
        }
        else
        {
           int maxnum = PlayerPrefs.GetInt("numcollect");
            numofCollect.text = maxnum + "/5";
        }
    }
       
    void LoadCollect()
    {
        PlayerPrefs.SetInt("numcollect", PlayerMovement.collection);
        int datacollect = PlayerPrefs.GetInt("numcollect");
        numofCollect.text = datacollect + "/5";

    }*/

        // Update is called once per frame
        void Update()
        {

        }
    }
}

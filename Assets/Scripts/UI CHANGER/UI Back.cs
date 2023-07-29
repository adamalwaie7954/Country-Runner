using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIsettings : MonoBehaviour
{
    [SerializeField] Button back;
    // Start is called before the first frame update
    void Start()
    {
        back.onClick.AddListener(goback);
    }

    private void goback()
    {
        scenemanager.Instance.MainMenu();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManagerEgyptScript2 : MonoBehaviour
{
    public GameObject spawnObject;
    public GameObject spawnObjectQuickSand;
    public GameObject[] spawnPoints;
    public float timer;
    public float timeBetweenSpawns;

    private float distance;

    public Text distanceUI;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        distanceUI.text = "DISTANCE: " + distance.ToString("F2") + " KM";
        timer += Time.deltaTime;

        distance += Time.deltaTime * 0.8f;

        if(timer > timeBetweenSpawns)
        {
            timer = 0;
            int randNum = Random.Range(0, 4);

            if(randNum == 3){
                Instantiate(spawnObjectQuickSand, spawnPoints[randNum].transform.position, Quaternion.identity);
                Debug.Log("Random3");
            }
            
            else{
            Instantiate(spawnObject, spawnPoints[randNum].transform.position, Quaternion.identity);
            Debug.Log("Random");
            } 
        }
    }
}
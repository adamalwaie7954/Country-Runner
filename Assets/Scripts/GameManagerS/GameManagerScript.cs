using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManagerScript : MonoBehaviour
{
    public GameObject spawnObject;
    public GameObject spawnObjectDurian;
    public GameObject spawnObjectDurianPos1;
    public GameObject spawnObjectDurianPos2;
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
            int randNum = Random.Range(0, 3);

            if(randNum == 1){
                Instantiate(spawnObjectDurian, spawnPoints[randNum].transform.position, Quaternion.identity);
                Instantiate(spawnObjectDurianPos1, spawnPoints[1].transform.position, Quaternion.identity);
                Instantiate(spawnObjectDurianPos2, spawnPoints[2].transform.position, Quaternion.identity);
                Debug.Log("Random1");
            }

            Instantiate(spawnObject, spawnPoints[randNum].transform.position, Quaternion.identity);
            
        }
    }
}


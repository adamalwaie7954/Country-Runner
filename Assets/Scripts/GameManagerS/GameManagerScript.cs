using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManagerScript : MonoBehaviour
{
    public GameObject spawnObject;
    public GameObject spawnObjectDurian;
    public GameObject spawnObjectDurianPos1;
    public GameObject spawnObjectDurianPos2;
    public GameObject spawnObjectWall;
    public GameObject spawnObjectLevelTransition;
    public GameObject spawnObjectSecretLevel;
    public GameObject[] spawnPoints;
    public GameObject blackscreen;
    public SpriteRenderer people;
    public SpriteRenderer mainsprite;
    public SpriteRenderer mainsprite1;
    public SpriteRenderer mainsprite2;
    public SpriteRenderer people1;
    public SpriteRenderer bg;
    public Sprite airportbg;
    public Sprite country;
    public Sprite spfield;
    public Sprite spairport;
    public Sprite spmarket;
    public Sprite sphuman;
    public Sprite spfieldcorn;
    public Sprite peopleline;
    public float timer;
    public float timeBetweenSpawns;

    public bool field = false;
    public bool airport = false;
    public bool changingscene = false;

    

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

            if (!changingscene)
            {
                if (randNum == 2)
                {
                    Instantiate(spawnObjectDurian, spawnPoints[randNum].transform.position, Quaternion.identity);
                    Instantiate(spawnObjectDurianPos1, spawnPoints[1].transform.position, Quaternion.identity);
                    Instantiate(spawnObjectDurianPos2, spawnPoints[2].transform.position, Quaternion.identity);

                    Debug.Log("Random1");
                }

                else if (randNum == 1)
                {
                    Instantiate(spawnObjectWall, spawnPoints[randNum].transform.position, Quaternion.identity);
                    Debug.Log("Random2");
                }

                else
                {
                    Instantiate(spawnObject, spawnPoints[randNum].transform.position, Quaternion.identity);
                    Debug.Log("Random");
                }
            }


            if (distance >= 60f){
                Instantiate(spawnObjectLevelTransition, spawnPoints[randNum].transform.position, Quaternion.identity);
                StartCoroutine(changeback());
                field = false;
                airport = false;
                Debug.Log("NextLevel");
            }

            if(distance >= 20f && !field)
            {
                field = true;
                StartCoroutine(changefieldscenes());
            }
            else if(distance >= 40f && !airport)
            {
                airport = true;
                StartCoroutine(changeairportscenes());
            }

            if (distance >= 25f && distance <= 28f){
                Instantiate(spawnObjectSecretLevel, spawnPoints[2].transform.position, Quaternion.identity);
            }           
        }
    }

    IEnumerator changefieldscenes()
    {
       changingscene = true;
       blackscreen.SetActive(true);
       yield return new WaitForSeconds(0.5f);
        blackscreen.SetActive(false);
        mainsprite.sprite = spfield;
        mainsprite1.sprite = spfield;
        mainsprite2.sprite = spfield;
        people.sprite = spfieldcorn;
        people1.sprite = spfieldcorn;
        changingscene = false;
    }

    IEnumerator changeairportscenes()
    {
        changingscene = true;
        blackscreen.SetActive(true);
        yield return new WaitForSeconds(0.5f);
        blackscreen.SetActive(false);
        mainsprite.sprite = spairport;
        mainsprite1.sprite = spairport;
        mainsprite2.sprite = spairport;
        people.sprite = peopleline;
        people1.sprite = peopleline;
        bg.sprite = airportbg;
        changingscene = false;
    }

    IEnumerator changeback()
    {
        changingscene = true;
        blackscreen.SetActive(true);
        yield return new WaitForSeconds(0.5f);
        blackscreen.SetActive(false);
        mainsprite.sprite = spmarket;
        mainsprite1.sprite = spmarket;
        mainsprite2.sprite = spmarket;
        bg.sprite = country;
        people.sprite = sphuman;
        changingscene = false;
    }
}


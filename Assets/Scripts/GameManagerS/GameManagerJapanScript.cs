using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManagerJapanScript : MonoBehaviour
{
    public GameObject spawnObject;
    public GameObject spawnObjectTrain;
    public GameObject[] spawnPoints;
    public PlayerMovement playerMovement;
    public GameObject spawnSecretLevelJapan;
    public GameObject spawnObjectYouWin;
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

    public bool field = false;
    public bool airport = false;
    public bool changingscene = false;



    public float timer;
    public float timeBetweenSpawns;

    private Rigidbody2D rb;
    //private bool isOnTrain = false;

    private float distance;

    public Text distanceUI;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        distanceUI.text = "DISTANCE: " + distance.ToString("F2") + " KM";
        timer += Time.deltaTime * 0.8f;

       
        distance += Time.deltaTime * 0.8f;
        
        if(distance >= 60f && distance <= 60.1f){
            Instantiate(spawnObjectYouWin, spawnPoints[2].transform.position, Quaternion.identity);
        }

        if(timer > timeBetweenSpawns)
        {
            timer = 0;
            int randNum = Random.Range(0, 3);
       
            if(randNum == 1){
                Instantiate(spawnObjectTrain, spawnPoints[randNum].transform.position, Quaternion.identity);
                Debug.Log("Random3");
            }
            
            else{
            Instantiate(spawnObject, spawnPoints[randNum].transform.position, Quaternion.identity);
            Debug.Log("Random");
            }

            if (distance >= 20f && !field)
            {
                field = true;
                StartCoroutine(changefieldscenes());
            }
            else if (distance >= 40f && !airport)
            {
                airport = true;
                StartCoroutine(changeairportscenes());
            }

            if (distance >= 25f && distance <= 28f)
            {
                Instantiate(spawnSecretLevelJapan, spawnPoints[2].transform.position, Quaternion.identity);
            }

        }
    }

    private void OnCollisionEnter2D(Collision2D other){
        if(other.gameObject.CompareTag("Train")){
            //isOnTrain=true;
            playerMovement.isGrounded=true;
        }
    }

    private void OnCollisionExit2D(Collision2D other){
        if(other.gameObject.CompareTag("Train")){
            //isOnTrain=false;
            playerMovement.isGrounded=true;
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

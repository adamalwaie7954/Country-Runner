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
}

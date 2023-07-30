using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    public static int collection = 0;
    public float maxSwipetime;
    public float minswipeDistance;

    private Vector2 starttouchpos;
    private Vector2 endtouchpos;

    private float swipeStartTime;
    private float swipeEndTime;
    private float swipeTime;
    private float swipelength;

    public float jump;
    private Rigidbody2D rb;
    public bool isGrounded;
    private float timer;

    public Animator mainanim;

    public AudioSource jumpaudio;
    public AudioSource slideaudio;
    public AudioSource landingaudio;

    //public GameManagerJapanScript gameManagerJapanScript;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if(!pausemenu.GameIsPaused)
        {
            SwipeTest();
        }
        if(Input.GetButtonDown("Jump") && isGrounded){
            StartCoroutine(jumping());
        }

        if(Input.GetKeyDown(KeyCode.LeftShift) && timer > 1){
                StartCoroutine(slideanim());
                timer = 0;
        }
    }
  

    private void OnCollisionEnter2D(Collision2D other){
        if(other.gameObject.CompareTag("Ground")){
            isGrounded=true;
        }
    }

    private void OnCollisionExit2D(Collision2D other){
        if(other.gameObject.CompareTag("Ground")){
            isGrounded=false;
        }
    }

    private void OnTriggerEnter2D(Collider2D other){
        if(other.gameObject.CompareTag("Enemy")){
            Debug.Log("Hit");
            collection += 5;
            scenemanager.Instance.MainMenu();
        }
    }

    void SwipeTest()
    {
        if(Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            if(touch.phase == TouchPhase.Began)
            {
                swipeStartTime = Time.time;
                starttouchpos = touch.position;
            }
            else if (touch.phase == TouchPhase.Ended)
            {
                swipeEndTime = Time.time;
                endtouchpos = touch.position;
                swipeTime = swipeEndTime - swipeStartTime;
                swipelength = (endtouchpos - starttouchpos).magnitude;
                if(swipeTime < maxSwipetime && swipelength > minswipeDistance)
                {
                    SwipeControl();
                }
            }    
        }
    }

    void SwipeControl()
    {
        Vector2 Distance = endtouchpos - starttouchpos;
        float xDistance = Mathf.Abs(Distance.x);
        float yDistance = Mathf.Abs(Distance.y);
        if(yDistance > xDistance)
        {
            if(Distance.y > 0 && isGrounded)
            {
                StartCoroutine(jumping());
            }
            else if(Distance.y < 0 && timer > 1)
            {
                StartCoroutine(slideanim());
                timer = 0;
            }
        }
    }

    IEnumerator slideanim()
    {
        mainanim.SetTrigger("slide");
        slideaudio.Play();
        yield return new WaitForSeconds(0.7f);
        mainanim.SetTrigger("slidedone");
    }

    IEnumerator jumping()
    {
        mainanim.SetTrigger("prejump");
        yield return new WaitForSeconds(0.2f);
        jumpaudio.Play();
        rb.AddForce(Vector2.up * jump);
        mainanim.SetTrigger("jump");
        yield return new WaitForSeconds(0.3f);
        mainanim.SetTrigger("falling");
        mainanim.SetTrigger("landing");
        yield return new WaitForSeconds(0.7f);
        landingaudio.Play();
    }
}

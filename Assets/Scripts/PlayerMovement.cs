using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
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
    private bool isGrounded;
    private float timer;

    public Animator anim;   

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
            rb.AddForce(Vector2.up * jump);
        }

        if(Input.GetKeyDown(KeyCode.LeftShift) && timer > 1){
            timer = 0;
            anim.SetTrigger("Slide");
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
                rb.AddForce(Vector2.up * jump);
            }
            else if(Distance.y < 0 && timer > 1)
            {
                timer = 0;
                anim.SetTrigger("Slide");
            }
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnObjectScript : MonoBehaviour
{
    private Rigidbody2D rb;
    public float speed;
    private float timer;
    public float killTimer = 5;
    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if(timer > killTimer){
            Destroy(gameObject);
        }
        rb.velocity = Vector2.left * speed;
    }
}

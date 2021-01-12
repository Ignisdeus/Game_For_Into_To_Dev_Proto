using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public bool canClimb = false; 
    void Update()
    {
        // player can move left and right 
        // for teaching I suggesting making the medhod long and explain it in more detail :) 
        Movement(); 

        // make it so player can't move out side the screen :) 
        EnforceLimits();
    }
    public float maxSpeed = 5f, jumpForce = 300f;
    float speed =0 ;
    public bool grounded = true; 
    void Movement()
    {
        speed *= 0.8f;
        speed += Input.GetAxisRaw("Horizontal") * maxSpeed * Time.deltaTime;
        transform.Translate(Vector2.right * speed);
        Mathf.Clamp(speed, 0, maxSpeed);

        if(Input.GetKey(KeyCode.Space) && grounded)
        {
            grounded = false; 
            Debug.Log("I'm Jumping");
            GetComponent<Rigidbody2D>().AddForce(Vector2.up * jumpForce);
        }

        if(canClimb)
        {
            transform.Translate(Vector2.up * Input.GetAxisRaw("Vertical") * Time.deltaTime);
            GetComponent<Rigidbody2D>().gravityScale = 0;
            gameObject.layer = 6; 
        }
        else
        {
            GetComponent<Rigidbody2D>().gravityScale = 1.75f;
            gameObject.layer = 7; 
        }

    }

    public Vector2 limits;
    void EnforceLimits()
    {

        if(transform.position.x < -limits.x) {
            transform.position = new Vector2(-limits.x, transform.position.y); 
        }
        if(transform.position.x > limits.x)
        {
            transform.position = new Vector2(limits.x, transform.position.y);
        }
        if(transform.position.y < -limits.y)
        {
            transform.position = new Vector2(transform.position.x, -limits.y);
        }
        if(transform.position.y > limits.y)
        {
            //transform.position = new Vector2(transform.position.x, limits.y);
        }
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if(other.gameObject.tag == "Ground")
        {
            grounded = true; 
        }
        if(other.gameObject.tag == "Ladder")
        {
            canClimb = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {

        if(other.gameObject.tag == "Ladder")
        {
            canClimb = false;
        }

    }
}

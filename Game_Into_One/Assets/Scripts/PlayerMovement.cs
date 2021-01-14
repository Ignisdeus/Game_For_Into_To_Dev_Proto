using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    float scaleOnX = 0;
    bool alive = true;
    public GameObject GM;
    public AudioClip jump, hitAudio,gainPoints;
    private AudioSource audioS; 
    void Start()
    {
        audioS = gameObject.AddComponent<AudioSource>(); 
        scaleOnX = hit.transform.localScale.x; 
        startingPos = transform.position; 
    }

    public bool canClimb = false; 
    void Update()
    {
        // player can move left and right 
        // for teaching I suggesting making the medhod long and explain it in more detail :) 
       if(alive)
        Movement(); 

        // make it so player can't move out side the screen :) 
        EnforceLimits();
    }
    public float maxSpeed = 5f, jumpForce = 300f;
    float speed =0 ;
    public bool grounded = true; 
    void Movement()
    {
        float horz = Input.GetAxisRaw("Horizontal");
        speed *= 0.8f;
        speed += horz * (maxSpeed * Time.deltaTime);
        transform.Translate(Vector2.right * speed);
        Mathf.Clamp(speed, 0, maxSpeed);

        if(Input.GetKey(KeyCode.Space) && grounded)
        {
            grounded = false;
            audioS.PlayOneShot(jump, 0.5f);
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

        if(horz < 0)
        {
            hit.transform.localScale = new Vector3(-scaleOnX, hit.transform.localScale.y, hit.transform.localScale.z);
            idle.transform.localScale = new Vector3(-scaleOnX, hit.transform.localScale.y, hit.transform.localScale.z);
        }
        if(horz > 0)
        {
            hit.transform.localScale = new Vector3(scaleOnX, hit.transform.localScale.y, hit.transform.localScale.z);
            idle.transform.localScale = new Vector3(scaleOnX, hit.transform.localScale.y, hit.transform.localScale.z);
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
    private void OnCollisionEnter2D(Collision2D other)
    {

        if(other.gameObject.tag == "Barrle")
        {
            audioS.PlayOneShot(hitAudio, 0.7f);
            Instantiate(bubbleEffect, transform.position, Quaternion.identity);
            alive = false;
            Destroy(other.gameObject); 
            StartCoroutine(HitAndReset());
        }
        if(other.gameObject.tag == "Goal") {
            audioS.PlayOneShot(gainPoints , 0.7f);
            LevelOver();
        }

    }
    public GameObject idle, hit, bubbleEffect;
    bool idleState = true;
    Vector2 startingPos;

    void LevelOver() {
        Instantiate(bubbleEffect, transform.position, Quaternion.identity);
        transform.position = startingPos;
        GM.GetComponent<GameMaster>().LevelComplete();
        Instantiate(bubbleEffect, transform.position, Quaternion.identity);
    }

    IEnumerator HitAndReset()
    {

        GM.GetComponent<GameMaster>().playerHit();
        for(int i =0; i < 5; i++)
        {
            
            idleState = !idleState;
            hit.SetActive(!idleState);
            yield return new WaitForSeconds(0.15f);
        }
        transform.position = startingPos; 
        hit.SetActive(false);
        alive = true; 
    }
}

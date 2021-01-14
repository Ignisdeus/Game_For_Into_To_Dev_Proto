using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boost : MonoBehaviour
{
    public bool isLeft;
    public Animator anim;
    public AudioClip boostAudio;
    private AudioSource audioS;
    private void Start()
    {
        audioS = gameObject.AddComponent<AudioSource>();
        //anim = GetComponent<Animator>();
    }
    public float force = 300; 
    private void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.GetComponent<Rigidbody2D>() == true)
        {
            audioS.PlayOneShot(boostAudio, 0.7f);
            anim.SetTrigger("Puff_up");
            if(isLeft) {
                other.gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.right * - force);
            }
            else
            {
                other.gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.right * force);
            }

        }
    }
}

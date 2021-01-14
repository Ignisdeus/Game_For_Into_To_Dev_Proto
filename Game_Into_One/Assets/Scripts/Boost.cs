using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boost : MonoBehaviour
{
    public bool isLeft;
    public Animator anim; 
    private void Start()
    {
        //anim = GetComponent<Animator>();
    }
    public float force = 300; 
    private void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.GetComponent<Rigidbody2D>() == true)
        {
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

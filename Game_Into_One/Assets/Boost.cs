using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boost : MonoBehaviour
{
    public bool isLeft;


    public float force = 300; 
    private void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.GetComponent<Rigidbody2D>() == true)
        {
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

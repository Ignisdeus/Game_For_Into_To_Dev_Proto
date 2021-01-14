using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block_Event : MonoBehaviour
{
    public GameObject expl;


    private void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.tag == "Barrle")
        {
            expl.SetActive(true);
            Destroy(this.gameObject); 
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestoryOnYPos : MonoBehaviour
{
    public float yPos; 
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.y < yPos)
            Destroy(this.gameObject); 
    }
}

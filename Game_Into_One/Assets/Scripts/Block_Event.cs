using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block_Event : MonoBehaviour
{
    public GameObject expl;
    public GameObject[] rubble;
    private AudioSource audioS;
    public AudioClip destoryAudio;
    private void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.tag == "Barrle")
        {
            audioS = gameObject.AddComponent<AudioSource>();
            audioS.PlayOneShot(destoryAudio, 0.7f);
            expl.SetActive(true);
            foreach(GameObject g in rubble)
            {
                g.SetActive(false); 
            }
            Destroy(this.gameObject, 1.2f); 
        }
    }
}

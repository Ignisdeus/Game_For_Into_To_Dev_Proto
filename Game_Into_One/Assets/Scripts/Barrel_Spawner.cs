using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barrel_Spawner : MonoBehaviour
{
    Animator anim;
    public ParticleSystem[] part;
    void Start()
    {
        anim = GetComponent<Animator>(); 
        StartCoroutine(SpawnBarrls());
    }

    public GameObject barrel;
    [Range(1f, 20f)]
    public float spawnTimeMax = 15f; 
    IEnumerator SpawnBarrls()
    {
        foreach(ParticleSystem p in part)
        {
            p.Stop();
            p.Clear();
            p.Play(); 
        }
        anim.SetTrigger("Fire");
        GameObject x = Instantiate(barrel, transform.position, Quaternion.identity);
        x.GetComponent<Rigidbody2D>().AddForce(Vector3.right * 300);
        yield return new WaitForSeconds(Random.Range(1f, spawnTimeMax));
        StartCoroutine(SpawnBarrls()); 

    }
}

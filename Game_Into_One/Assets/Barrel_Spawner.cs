using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barrel_Spawner : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnBarrls());
    }

    public GameObject barrel;
    [Range(1f, 20f)]
    public float spawnTimeMax = 15f; 
    IEnumerator SpawnBarrls()
    {
       
        GameObject x = Instantiate(barrel, transform.position, Quaternion.identity);
        x.GetComponent<Rigidbody2D>().AddForce(Vector3.right * 300);
        yield return new WaitForSeconds(Random.Range(1f, spawnTimeMax));
        StartCoroutine(SpawnBarrls()); 

    }
}

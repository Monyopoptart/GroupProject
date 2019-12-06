using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GS : MonoBehaviour

  

{
    public float speed = 10;
    public float lifeTime = 3;
    public GameObject prefabToSpawn;
    public float spawnDelay = 10;

    // Start is called before the first frame update
    void Start()
    {
        SpawnObject();
        
    }

    // Update is called once per frame
    void Update()
    {
        //if (prefabToSpawn != null)
        //{
        //        StartCoroutine(Spawn());
        //    
        //
        //}
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (prefabToSpawn != null)
        {
            if (col.gameObject.tag == "Player")
            {
                StartCoroutine(Spawn());
            }

        }
    }


    IEnumerator Spawn()
    {
        yield return new WaitForSeconds(1f);
        GameObject spawnedObject = Instantiate(prefabToSpawn, transform.position, transform.rotation);

        //SpawnObject();
        //spawnedObject.GetComponent<Rigidbody2D>().AddForce(Random.insideUnitCircle * 50);
        //Spawn();

    }
    public void SpawnObject()
    {
        StartCoroutine(Spawn());
        Invoke("SpawnObject", spawnDelay);
    }
}

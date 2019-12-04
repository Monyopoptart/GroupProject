using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public float speed = 10;
    public float lifeTime = 3;
    public GameObject prefabToSpawn;
    public float spawnDelay = 10;

    // Start is called before the first frame update
    void Start()
    {
        Spawn();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (prefabToSpawn!=null)
        {
            if(col.gameObject.tag == Player)

        }
    }


    public void Spawn()
    {
        GameObject spawnedObject = Instantiate(prefabToSpawn,
            transform.position, transform.rotation);
        spawnedObject.GetComponent<Rigidbody2D>().AddForce(Random.insideUnitCircle * 50);
        Invoke("Spawn", spawnDelay);
    }
    IEnumerator Spawn()
    {
        GameObject spawnedObject = Instantiate(prefabToSpawn,
            transform.position, transform.rotation);
        spawnedObject.GetComponent<Rigidbody2D>().AddForce(x.insideUnitCircle * 50);

    }
}

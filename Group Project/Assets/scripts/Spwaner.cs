using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//Amber and Michael Worked on this. However, we use the GS script instead of this one to spawn lazers and things
public class Spwaner : MonoBehaviour
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
        GameObject spawnedObject = Instantiate(prefabToSpawn,
            transform.position, transform.rotation);
        //spawnedObject.GetComponent<Rigidbody2D>().AddForce(Random.insideUnitCircle * 50);

    }
}

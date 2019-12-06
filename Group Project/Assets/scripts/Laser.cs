using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    public int speed = 2;
    public float lifetime = 5;
    public Globals global;
    // Start is called before the first frame update
    void Start()
    {

    }
    private void Moveleft()
    {
        transform.position += new Vector3(-speed * Time.deltaTime, 0,0);


    }
   
    // Update is called once per frame
    void Update()
    {
       Invoke( "Moveleft",lifetime);   
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag=="Player")
        {
            //global.changePlayerHealth(-15);
            Destroy(gameObject);

        }
    }
}

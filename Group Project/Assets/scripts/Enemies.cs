using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemies : MonoBehaviour
{
    // Start is called before the first frame update
    Score scoreComponent;
    public Transform target;
    public float speed = 3;
    void Start()
    {
        scoreComponent = GameObject.FindObjectOfType<Score>();
        target = GameObject.FindObjectOfType<PlayerControls>().transform;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 deltaVec = target.position - transform.position;
        deltaVec = Vector3.Normalize(deltaVec);

        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        if(rb != null)
            rb.velocity = deltaVec * speed;
        else
            transform.position += deltaVec * speed * Time.deltaTime;
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log(collision.gameObject.name);

        //if(collision.gameObject.tag == "laser")
        if (collision.gameObject.GetComponent<Sword>() != null)
        {
            
            Debug.Log("Test2");
            scoreComponent.ChangeScore(1);
            Destroy(gameObject);
        }
        else if (collision.gameObject.GetComponent<PlayerControls>() != null)
        {
            collision.gameObject.GetComponent<PlayerControls>().ChangeHealth(-10);
        }
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target; 
    public float speed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (target == null)
        {
            Debug.Log("No Target Set");
            return; //If no target is set
        }
        Vector3 changeInPosition = target.position - transform.position; //Figure out how far away target is
        changeInPosition = Vector3.Normalize(changeInPosition); //Normalze distance so we have direction
        //Debug.Log("Target Distance Normalized");
        //transform.right = changeInPosition;

        //Rigidbody2D rb = GetComponent<Rigidbody2D>();
        //if (rb != null && rb.gravityScale != 0)
        //    rb.velocity = changeInPosition * speed * Time.deltaTime; // works when gravity is not 0. Allows object to gain velocity
        //else
            transform.position += new Vector3 (changeInPosition.x * speed * Time.deltaTime, changeInPosition.y * speed * Time.deltaTime, 0); // This works for when gravity is 0 and forces gameobject to 'teleport'
    }
}

﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Robert Bunch worked on this 


public class FireGolbin : MonoBehaviour
{
    public int firehealth = 100;
    public int enemyPointValue = 100;
    Score scoreComponent;
    public Transform target;
    public float speed = 3;
  

    // Start is called before the first frame update
    void Start()
    {
        //scoreComponent = GameObject.FindObjectOfType<Score>();
        target = GameObject.FindObjectOfType<PlayerControls>().transform;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 deltaVec = target.position - transform.position;
        deltaVec = Vector3.Normalize(deltaVec);

        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        if (rb != null)
            rb.velocity = deltaVec * speed;
        else
            transform.position += deltaVec * speed * Time.deltaTime;

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        
        //if(collision.gameObject.tag == "laser")
        if (collision.gameObject.GetComponent<Sword>() != null)
        {
            Debug.Log(firehealth);
            firehealth -= 25;
            if(firehealth == 0)
            {
                //scoreComponent.ChangeScore(1);
                GameObject.FindObjectOfType<Globals>().changePlayerScore(enemyPointValue);
                Destroy(gameObject);
            }
        }
        if (collision.gameObject.tag == "Sword")
        {
            Debug.Log(firehealth);
            firehealth -= 25;
            if (firehealth == 0)
            {
                //scoreComponent.ChangeScore(1);
                GameObject.FindObjectOfType<Globals>().changePlayerScore(enemyPointValue);
                Destroy(gameObject);
            }
        }
        if (collision.gameObject.tag == "Hook")
        {
            Debug.Log("Hook Collided");
            //scoreComponent.ChangeScore(1);
            firehealth -= 25;
            if (firehealth == 0)
            {
                //scoreComponent.ChangeScore(1);
                GameObject.FindObjectOfType<Globals>().changePlayerScore(enemyPointValue);
                Destroy(gameObject);
            }

        }
        //else if (collision.gameObject.GetComponent<PlayerControls>() != null)
        //{
        //    collision.gameObject.GetComponent<PlayerControls>().ChangeHealth(-25);
        //}
    }
}

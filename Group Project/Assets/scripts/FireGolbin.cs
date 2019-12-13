using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Robert Bunch worked on this 


public class FireGolbin : MonoBehaviour
{
    public int firehealth = 100;
    public int enemyPointValue = 100;
    Score scoreComponent;
    public Transform target;
    public Transform BoundaryLeft;
    public Transform BoundaryRight;
    public float speed = 3;
    public AudioClip soundEffect;
    public AudioSource musicSource;
    bool isLeft;
    bool isRight;



    // Start is called before the first frame update
    void Start()
    {
        //scoreComponent = GameObject.FindObjectOfType<Score>();
        //target = GameObject.FindObjectOfType<PlayerControls>().transform;
        isLeft = true;
        isRight = true;
    }

    // Update is called once per frame
    void Update()
    {

        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        if (target != null) //If goblin has a target, follow the target
        {
            Vector3 deltaVec = target.position - transform.position;
            deltaVec = Vector3.Normalize(deltaVec); //find direction and normalize

            if (rb != null) //This should always be true.
                rb.velocity = deltaVec * speed; //Follow target
            else
                Debug.Log("This script will crash. You need to give this object a RigidBody");    
  
        }
        else //If no target, patrol between the two boundaries
        {
            Debug.Log("There is no Target. This unit will Patrol");
            Patrol();
        }

    }

    private void Patrol() //Swaps target between bourndaries
    {
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        //Both start true, so left boundary will be first target
        if (isLeft) 
        {
            Debug.Log("Moving towards left boundary");
            Vector3 deltaVec = BoundaryLeft.position - transform.position;
            deltaVec = Vector3.Normalize(deltaVec);

            rb.velocity = deltaVec * speed;

            if (BoundaryLeft.position.x+1 >= transform.position.x)
            {
                Debug.Log("Shifting to right boundary");
                isLeft = false;
                isRight = true;
            }
        }
        else if (isRight)
        {
            Debug.Log("Moving towards right boundary");
            Vector3 deltaVec = BoundaryRight.position - transform.position;
            deltaVec = Vector3.Normalize(deltaVec);

            rb.velocity = deltaVec * speed;

            if (BoundaryRight.position.x-1 <= transform.position.x)
            {
                Debug.Log("Shifting to left boundary");
                isLeft = true;
                isRight = false;
            }
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (musicSource != null)
        {
            musicSource.clip = soundEffect;
            musicSource.Play();
        }

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

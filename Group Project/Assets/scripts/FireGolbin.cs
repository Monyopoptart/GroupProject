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



    // Start is called before the first frame update
    void Start()
    {
        //scoreComponent = GameObject.FindObjectOfType<Score>();
        target = GameObject.FindObjectOfType<PlayerControls>().transform;
    }

    // Update is called once per frame
    void Update()
    {

        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        if (target != null)
        {
            Vector3 deltaVec = target.position - transform.position;
            deltaVec = Vector3.Normalize(deltaVec);
            if (gameObject.transform.position.x > BoundaryLeft.position.x && gameObject.transform.position.x < BoundaryRight.position.x) //Checks to see if the goblin is within the boundaries set up
            {
                if (rb != null)
                    rb.velocity = deltaVec * speed;
                else
                    transform.position += deltaVec * speed * Time.deltaTime;
            }
            else //If it is not, will move in the opposite direction
                rb.velocity = deltaVec * -speed;
        }
        else
            return;

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

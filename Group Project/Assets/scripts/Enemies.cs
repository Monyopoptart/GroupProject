using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Robert Bunch and Michael Sheen worked on this
public class Enemies : MonoBehaviour
{
    // Start is called before the first frame update
    Score scoreComponent;
    public Transform target;
    public float speed = 3;
    public int enemyPointValue = 100;
    public AudioClip IntroMusic;
    public AudioSource musicSource;
    void Start()
    {
        //scoreComponent = GameObject.FindObjectOfType<Score>(); Is the score script necessary since the portal is our objective?
        if (target != null)
            target = GameObject.FindObjectOfType<PlayerControls>().transform;
        else
            Debug.Log("No target linked in");
        
    }

    // Update is called once per frame
    void Update()
    {
        if (target != null)
        {
            Vector3 deltaVec = target.position - transform.position;
            deltaVec = Vector3.Normalize(deltaVec);

            Rigidbody2D rb = GetComponent<Rigidbody2D>();
            if (rb != null)
                rb.velocity = deltaVec * speed;
            else
                transform.position += deltaVec * speed * Time.deltaTime;
        }
        else
            Debug.Log("No target hooked in.");
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log(collision.gameObject.name);
        if (musicSource != null)
        {
            musicSource.clip = IntroMusic;
            musicSource.Play();
        }
        //if(collision.gameObject.tag == "laser")
        if (collision.gameObject.GetComponent<Sword>() != null)
        {
            
            Debug.Log("Test2");
            //scoreComponent.ChangeScore(1);
            GameObject.FindObjectOfType<Globals>().changePlayerScore(enemyPointValue);
            Destroy(gameObject);
        }
        if (collision.gameObject.tag == "Sword")
        {
            Debug.Log("Sword Collided");
            //scoreComponent.ChangeScore(1);
            GameObject.FindObjectOfType<Globals>().changePlayerScore(enemyPointValue);
            Destroy(gameObject);
            
        }
        if (collision.gameObject.tag == "Hook")
        {
            Debug.Log("Hook Collided");
            //scoreComponent.ChangeScore(1);
            GameObject.FindObjectOfType<Globals>().changePlayerScore(enemyPointValue);
            Destroy(gameObject);

        }
        //else if (collision.gameObject.GetComponent<PlayerControls>() != null)
        //{
        //    collision.gameObject.GetComponent<PlayerControls>().ChangeHealth(-10);
        //}
    }

}

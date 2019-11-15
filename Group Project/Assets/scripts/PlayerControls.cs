using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerControls : MonoBehaviour
{
    public Slider healthBar;
    public float speed = 5;
    Transform playerFeet;
	Rigidbody2D rb;
    bool canJump = false;
    public int health = 100;
    Vector3 startPoint;
    Animator anim;
    SpriteRenderer sr;
    Transform sword = null;

    void Start ()
    {
        anim = GetComponent<Animator>();
        startPoint = transform.position;
		rb = GetComponent<Rigidbody2D>();
        playerFeet = transform.GetChild(0);
        sr = GetComponent<SpriteRenderer>();
        sword = transform.GetChild(1);
    }

    public void Respawn()
    {
        transform.position = startPoint;
    }

    public void EnableGun()
    {
        sword.gameObject.SetActive(true);
    }

    public void ChangeHealth(int change)
    {
        health += change;
        healthBar.value = health / 100.0f;
        if (health <= 0)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }

    void Update()//More responsive - checks our input each frame
    {
        float movementX = Input.GetAxis("Horizontal");
        if(Mathf.Abs(movementX) > 0)
        {
            if (movementX < 0)
            {
                  transform.localScale = new Vector3(-1, 1, 1);
               // if (sr.flipX != true)
                //{
                  //  sr.flipX = true;
                  //  Vector3 vec = sword.transform.localPosition;
                  //  vec.x *= -1;
                  //  sword.transform.localPosition = vec;
               // }
            }
            else
            {
                transform.localScale = new Vector3(1, 1, 1);
               // if (sr.flipX != false)
                //{
                 //   sr.flipX = false;
                 //   Vector3 vec = sword.transform.localPosition;
                   // vec.x *= -1;
                   // sword.transform.localPosition = vec;
                //}
            }
            rb.velocity = new Vector2(movementX * speed, rb.velocity.y);
            anim.SetBool("is Walking", true);
        }
        else
            anim.SetBool("is Walking", false);

        float jumpValue = Input.GetAxis("Jump");
            canJump = false;
        if (jumpValue > 0)
        {
            //trying to jump here
            Collider2D[] collisions 
                = Physics2D.OverlapCircleAll(playerFeet.position, .25f);

            //Ray casting
            //means 'cast' or draw a ray out in one direction and check
            //what colliders we encounter in that direction
            //Physics2D.RaycastAll(playerFeet.position, new Vector2(0, -1), 1);

            for(int i = 0; i < collisions.Length; ++i)
            {
                if (collisions[i].gameObject != gameObject)
                {
                    canJump = true;
                    break;
                }
            }
        }
    }
	
	void FixedUpdate()//Synced with physics, do movement here, input in Update
    {
        if (canJump)
        {
            rb.velocity = new Vector2(rb.velocity.x, 0);
            rb.AddForce(new Vector2(0, 350));
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        
    }
}

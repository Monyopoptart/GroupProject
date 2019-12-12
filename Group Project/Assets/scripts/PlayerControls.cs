using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

//Robert Bunch worked on this
public class PlayerControls : MonoBehaviour
{
    //public Slider healthBar; By changing health to global, we no longer need this
    public float speed = 5;
    public Globals global;
    Transform playerFeet;
    Transform sword = null;
	Rigidbody2D rb;
    bool canJump = false;
    private bool canSwim = false;
    //public int health = 100; By changing health to global, we no longer need this
    Vector3 startPoint;
    Animator anim;
    SpriteRenderer sr;

    void Start ()
    {
        anim = GetComponent<Animator>();
        startPoint = transform.position;
		rb = GetComponent<Rigidbody2D>();
        playerFeet = gameObject.transform.GetChild(0);
        canSwim = false;
        sr = GetComponent<SpriteRenderer>();
        sword = transform.GetChild(2); //save for later. Hit box soon
    }

    public void Respawn()
    {
        transform.position = startPoint;
    }

    public void EnableGun()
    {
        sword.gameObject.SetActive(true);
    }

    //public void ChangeHealth(int change)
    //{
    //    health += change;
    //    healthBar.value = health / 100.0f;
    //    if (health <= 0)
    //    {
    //        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    //    }
    //}

    void Update()//More responsive - checks our input each frame
    {
        float movementX = Input.GetAxis("Horizontal");
        if(Mathf.Abs(movementX) > 0)
        {
            if (movementX < 0)
            {
                  transform.localScale = new Vector3(-1, 1, 1);
                  transform.GetChild(0).transform.localScale = new Vector3(-1, 1, 1);
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
                transform.GetChild(0).transform.localScale = new Vector3(1, 1, 1);
                // if (sr.flipX != false)
                //{
                //   sr.flipX = false;
                //   Vector3 vec = sword.transform.localPosition;
                // vec.x *= -1;
                // sword.transform.localPosition = vec;
                //}
            }
            rb.velocity = new Vector2(movementX * speed, rb.velocity.y);
            sword.transform.position = Vector3.MoveTowards(gameObject.transform.position, sword.transform.position, 0);
            anim.SetBool("is Walking", true);
        }
        else
            anim.SetBool("is Walking", false);

        
        
        #region Attacking
        float attackValue = Input.GetAxis("Fire1");
        if (attackValue > 0)
        {
            sword.GetComponent<BoxCollider2D>().enabled=true;
            anim.SetBool("isattacking", true);
        }
        else
        {
            sword.GetComponent<BoxCollider2D>().enabled = false;
            anim.SetBool("isattacking", false);
        }


        #endregion
        #region Swimming and Jumping

            float jumpValue = Input.GetAxis("Jump");
        if (canSwim)
        {
            anim.SetBool("isSwimming", true);
            if (jumpValue >0)
                canJump = true;
        }
        else
        {
            anim.SetBool("isSwimming", false);
            canJump = false;
            if (jumpValue > 0)
            {
                //trying to jump here
                playerFeet = gameObject.transform.GetChild(1);

                Collider2D[] collisions = Physics2D.OverlapCircleAll(playerFeet.position, .5f);

                //Ray casting
                //means 'cast' or draw a ray out in one direction and check
                //what colliders we encounter in that direction
                //Physics2D.RaycastAll(playerFeet.position, new Vector2(0, -1), 1);

                for (int i = 0; i < collisions.Length; ++i)
                {
                    if (collisions[i].gameObject != gameObject)
                    {
                        Debug.Log("Can jump is true");
                        canJump = true;
                        break;
                    }
                }
            }
        }

        #endregion

    }

    void FixedUpdate()//Synced with physics, do movement here, input in Update
    {
        if (canJump)
        {
            rb.velocity = new Vector2(rb.velocity.x, 0);
            rb.AddForce(new Vector2(0, 350));
            canJump = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //Debug.Log("Collision Occurred");
        if (collision.gameObject.tag == "Enemy")
        {
            global.changePlayerHealth(-10);
            //Globals.changePlayerHealthStatic(-10); //For now, any collisions with enemy causes damage
            Debug.Log("Enemy touched you");
        }
    }
    public void enableSwim()
    {
        canSwim = !canSwim;
        
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Robert Bunch worked on this
public class Sword : MonoBehaviour
{
    public AudioClip Firecracker;
    Collider2D col = null;
    public GameObject SwordPrefab;
    Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        anim = FindObjectOfType<PlayerControls>().gameObject.GetComponent<Animator>();
        col = GetComponent<Collider2D>();
        col.enabled = false;
    }

    void Update()
    {
        float attackValue = Input.GetAxis("Fire1");
        //ive tried making it a trigger and it still did not work 
        //Ive moved the colltion box so that it doesn't overlap the player box
        if (attackValue > 0)
        {
            col.enabled = true;
            //Instantiate(SwordPrefab, transform.position, transform.rotation);
            anim.SetBool("isattacking", true);
            AudioSource.PlayClipAtPoint(Firecracker, gameObject.transform.position);
        }
        else
        {
            col.enabled = false;
            anim.SetBool("isattacking", false);
        }

    }
}

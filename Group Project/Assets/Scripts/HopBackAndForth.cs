using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//Phillip worked on this
public class HopBackAndForth : MonoBehaviour
{
    public float magnitude = 1.0f;
    public float hopForceX = 50.0f;
    public float hopForceY = 250.0f;
    public float baseHopDelay = 3.0f;
    private Rigidbody2D rb;
    private SpriteRenderer sr;
    private Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
        Invoke("Hop", GetHopDelay());
    }

    private void Update()
    {
        anim.SetFloat("VerticalVelocity", Mathf.Abs(rb.velocity.y));
    }

    float GetHopDelay()
    {
        return baseHopDelay + Random.Range(0.0f, 3.0f);
    }

    void FlipAndHop()
    {
        magnitude *= -1;
        if (sr.flipX)
            sr.flipX = false;
        else
            sr.flipX = true;

        Hop();
    }

    void Hop()
    {
        rb.AddForce(new Vector2(hopForceX * magnitude, hopForceY));
        Invoke("FlipAndHop", GetHopDelay());
    }
}

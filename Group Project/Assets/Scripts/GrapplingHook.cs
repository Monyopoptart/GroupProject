using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrapplingHook : MonoBehaviour
{
    public float grappleForce = 2.0f;
    bool readyToFire = false;
    Vector2 mousePos;
    Vector2 objPos;
    float mouseAngle;
    Rigidbody2D playerRB;
    Rigidbody2D grapplingRB;
    CircleCollider2D grapplingCol;
    SpriteRenderer grapplingSR;

    // Start is called before the first frame update
    void Start()
    {
        playerRB = GetComponentInParent<Rigidbody2D>();
        grapplingRB = GetComponentInChildren<Rigidbody2D>();
        grapplingCol = GetComponentInChildren<CircleCollider2D>();
        grapplingCol.enabled = false;
        grapplingSR = GetComponentInChildren<SpriteRenderer>();
        grapplingSR.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetAxisRaw("Fire3") != 0) // Hold fire, aim
        {
            readyToFire = true;
            grapplingSR.enabled = true;
        }
        else if (Input.GetAxisRaw("Fire3") == 0) // Release fire
        {
            if(readyToFire)
            {
                readyToFire = false;
                grapplingCol.enabled = true;
                grapplingRB.AddForce(gameObject.transform.forward * grappleForce);
            }
        }

        // Finding angle of mouse
        mousePos = Input.mousePosition;
        objPos = Camera.main.WorldToScreenPoint(transform.position);
        mousePos.x -= objPos.x;
        mousePos.y -= objPos.y;
        mouseAngle = Mathf.Atan2(mousePos.y, mousePos.x);
        Debug.Log("mouseAngleAngle = " + mouseAngle);
    }
}

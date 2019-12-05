using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrapplingHook : MonoBehaviour
{
    public float grappleForce = 1000.0f;
    public float ropeWidth = 0.05f;
    bool readyToFire = false, firing = false;
    Vector2 mousePos, objPos;
    float mouseAngle;
    Rigidbody2D playerRB, grapplingRB;
    GameObject grapple;
    CircleCollider2D grapplingCol;
    SpriteRenderer grapplingSR;
    LineRenderer line;

    // Start is called before the first frame update
    void Start()
    {
        playerRB = GetComponentInParent<Rigidbody2D>();
        line = GetComponent<LineRenderer>();
        grapplingRB = GetComponentInChildren<Rigidbody2D>();
        grapplingCol = GetComponentInChildren<CircleCollider2D>();
        grapplingSR = GetComponentInChildren<SpriteRenderer>();
        grapple = grapplingRB.gameObject;
        grapplingRB.isKinematic = true;
        grapplingCol.enabled = false;
        grapplingSR.enabled = false;

        // Set the width of the Line Renderer
        line.startWidth = ropeWidth;
        line.endWidth = ropeWidth;
        line.positionCount = 2;
    }

    // Update is called once per frame
    void Update()
    {
        if (!firing)
        {
            if (Input.GetAxisRaw("Fire3") != 0) // Hold fire, aim
            {
                readyToFire = true;
                grapplingSR.enabled = true;
            }
            else if (Input.GetAxisRaw("Fire3") == 0) // Release fire
            {
                if (readyToFire)
                {
                    readyToFire = false;
                    grapplingRB.isKinematic = false;
                    grapplingCol.enabled = true;
                    grapplingRB.AddRelativeForce(new Vector2(grappleForce, grappleForce));
                }
            }

            // Finding angle of mouse
            mousePos = Input.mousePosition;
            objPos = Camera.main.WorldToScreenPoint(transform.position);
            mousePos.x -= objPos.x;
            mousePos.y -= objPos.y;

            // Rotating GrappleArm to follow mouse
            Quaternion targetRotation = Quaternion.AngleAxis(Mathf.Atan2(mousePos.y, mousePos.x) * Mathf.Rad2Deg, Vector3.forward);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, 5.0f * Time.deltaTime);
        }

        // Drawing line to grappling hook
        if(grapplingSR.enabled)
        {
            line.SetPosition(0, gameObject.transform.position);
            line.SetPosition(1, grapple.transform.position);
        }
    }

    // Changes the firing state
    public void SetFiring(bool enabled)
    {
        firing = enabled;
    }
}

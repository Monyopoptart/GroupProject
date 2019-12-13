using UnityEngine;

//Phillip worked on this
public class GrapplingHook : MonoBehaviour
{
    public float grappleForce = 750.0f;
    public float pullForce = 750.0f;
    public float maxPullTime = 2.0f;
    public float maxPullVelocity = 40.0f;
    public float maxClawVelocity = 40.0f;
    public float ropeWidth = 0.05f;
    bool readyToFire = false, firing = false, pulling = false;
    float mouseAngle;
    Vector2 mousePos, objPos, direction;
    Vector2 initGrapplePos;
    Quaternion initGrappleRot;
    Rigidbody2D playerRB, grapplingRB;
    GameObject grapple;
    CircleCollider2D grapplingCol;
    SpriteRenderer grapplingSR;
    GrapplingClaw claw;
    LineRenderer line;

    // Start is called before the first frame update
    void Start()
    {
        playerRB = GetComponentInParent<Rigidbody2D>();
        line = GetComponent<LineRenderer>();
        grapplingRB = GetComponentInChildren<Rigidbody2D>();
        grapplingCol = GetComponentInChildren<CircleCollider2D>();
        grapplingSR = GetComponentInChildren<SpriteRenderer>();
        claw = GetComponentInChildren<GrapplingClaw>();
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
                line.enabled = true;
            }
            else if (Input.GetAxisRaw("Fire3") == 0) // Release fire
            {
                if (readyToFire)
                {
                    readyToFire = false;
                    firing = true;
                    grapplingRB.isKinematic = false;
                    grapplingCol.enabled = true;
                    grapplingRB.AddRelativeForce(new Vector2(grappleForce, grappleForce));
                    grapple.transform.parent = null; // Removes gameObject as parent
                    claw.ThrowInitiated();
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

        // Pulls
        else if (pulling)
        {
            direction = grapple.transform.position;
            direction.x -= transform.position.x;
            direction.y -= transform.position.y;
            direction.Normalize();
            if(playerRB.velocity.magnitude < maxPullVelocity)
            {
                playerRB.AddForce(direction * pullForce);
            }
        }

        // Drawing line to grappling hook
        if(grapplingSR.enabled)
        {
            line.SetPosition(0, transform.position);
            line.SetPosition(1, grapple.transform.position);
        }

    }

    // Freezes grapple in place
    public void FreezeGrapple()
    {
        grapplingRB.isKinematic = true;
        grapplingRB.velocity = Vector2.zero;
        grapplingRB.angularVelocity = 0;
    }

    // Activates pulling the player towards grapple
    public void GrapplePull()
    {
        pulling = true;
        Invoke("GrappleTimeout", maxPullTime);
    }

    // Resets the grapple if it is still pulling
    void GrappleTimeout()
    {
        ResetGrapple();
    }

    // Resets the grapple to where it was
    public void ResetGrapple()
    {
        grapple.transform.parent = transform; // Resets the parent 
        readyToFire = false;
        firing = false;
        pulling = false;
        grapplingRB.isKinematic = true;
        grapplingCol.enabled = false;
        grapplingSR.enabled = false;
        grapple.transform.localPosition = new Vector2(0 + 2, 0);
        grapple.transform.localRotation = Quaternion.Euler(0, 0, -45);
        grapplingRB.velocity = Vector2.zero;
        grapplingRB.angularVelocity = 0;
        claw.ResetAttachment();
        CancelInvoke();
        Debug.Log("Successful Reset");

        line.enabled = false;
    }
}

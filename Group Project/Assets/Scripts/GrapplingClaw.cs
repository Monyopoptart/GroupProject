using UnityEngine;

public class GrapplingClaw : MonoBehaviour
{
    public float maxThrowTime = 2.0f;
    bool throwFinish = false;
    bool throwReset = true;
    GrapplingHook hook;

    private void Start()
    {
        hook = gameObject.GetComponentInParent<GrapplingHook>();
        Invoke("GrappleTimeout", maxThrowTime);
    }
    
    private void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject.tag == "Player" || col.gameObject.tag == "Enemy") // When hitting the player or enemy
        {
            hook.ResetGrapple();
        }
        else // When hitting another surface
        {
            hook.FreezeGrapple();
            hook.GrapplePull();
            throwFinish = true;
        }
    }

    // Indicates the throw has begun
    public void ThrowInitiated()
    {
        throwReset = false;
    }

    // Resets the state of the claw to indicate it has been reset
    public void ResetAttachment()
    {
        throwFinish = false;
        throwReset = true;
        Debug.Log("Detached");
    }

    // Resets the hook if it is being thrown and hasn't hit anything
    private void GrappleTimeout()
    {
        Debug.Log("Attempting grapple throw timeout");
        if (!throwFinish && !throwReset)
        {
            hook.ResetGrapple();
        }
    }
}

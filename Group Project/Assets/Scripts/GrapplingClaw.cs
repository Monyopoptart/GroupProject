using UnityEngine;

//Phillip worked on this
public class GrapplingClaw : MonoBehaviour
{
    public float maxThrowTime = 2.0f;
    bool throwFinish = false;
    GrapplingHook hook;

    private void Start()
    {
        hook = gameObject.GetComponentInParent<GrapplingHook>();
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
        Invoke("GrappleTimeout", maxThrowTime);
    }

    // Resets the state of the claw to indicate it has been reset
    public void ResetAttachment()
    {
        throwFinish = false;
        CancelInvoke();
        Debug.Log("Detached");
    }

    // Resets the hook if it is being thrown and hasn't hit anything
    private void GrappleTimeout()
    {
        Debug.Log("Attempting grapple throw timeout");
        if (!throwFinish)
        {
            hook.ResetGrapple();
        }
    }
}

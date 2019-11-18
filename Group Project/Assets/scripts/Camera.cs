using UnityEngine;

public class Camera : MonoBehaviour
{
    public GameObject objectToFollow;
    Rigidbody2D rb;
    public float horizOffset = 2.0f; // Horizontal offset

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (objectToFollow != null)
        {
            // This allows the camera to follow the player pretty smoothly
            rb.velocity = new Vector2(objectToFollow.transform.position.x - gameObject.transform.position.x, (objectToFollow.transform.position.y + horizOffset) - gameObject.transform.position.y) * 4;

            /* Saving this code from class just in case what I made doesn't work
            Vector3 pos = objectToFollow.transform.position;

            gameObject.transform.position =
                new Vector3(pos.x, pos.y, gameObject.transform.position.z);
            */
        }
        else
        {
            rb.velocity = new Vector2(0, 0); // Resets velocity if player dies
        }
    }
}
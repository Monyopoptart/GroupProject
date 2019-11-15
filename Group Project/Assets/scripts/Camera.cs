using UnityEngine;

public class Camera : MonoBehaviour
{
    public GameObject objectToFollow;

    void Start()
    {
        
    }

    void Update()
    {
        if(objectToFollow != null)
        {
            Vector3 pos = objectToFollow.transform.position;

            gameObject.transform.position =
                new Vector3(pos.x, pos.y, gameObject.transform.position.z);
        }
    }
}

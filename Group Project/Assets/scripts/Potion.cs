using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Robert Bunch worked on this
public class Potion : MonoBehaviour
{
    public int healing = 0;
    public GameObject Global;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<PlayerControls>() != null)
        {
            Global.GetComponent<Globals>().changePlayerHealth(50);
            Destroy(gameObject);
        }

    }
}

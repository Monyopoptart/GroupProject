using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Robert Bunch and Michael worked on this
public class Killzone : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        PlayerControls player = collision.gameObject.GetComponent<PlayerControls>();
        if (player != null)
            player.Respawn();
        else
        {
            Debug.Log("Something touched the Killzone");
        }
    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

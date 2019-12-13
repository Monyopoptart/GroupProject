using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//I dont think we actually use this script but it's here anyway. Uh I think Amber and Michael worked on this but I'm not sure and I don't remember
public class myGameMangager : MonoBehaviour
{
    Score count;

    // Start is called before the first frame update
    void Start()
    {
        count = FindObjectOfType<Score>();
        if(PlayerPrefs.HasKey("Score"))
        {
            count.SetScore(PlayerPrefs.GetInt("Score"));
        }
       // count.getScore(); //had to make pubic or it was inacasse able due to protection level
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

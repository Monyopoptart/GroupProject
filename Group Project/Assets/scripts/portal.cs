using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
//Robert Bunch worked on this
public class portal : MonoBehaviour
{
    public string levelToSwichTo;
    //Score count = FindObjectOfType<Score>(); We don't want to use FindObjectsOfType because they take up a lot of memeroy and we can reference Score directly -Michael.

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            //PlayerPrefs.SetInt("Score", count.getScore());
            PlayerPrefs.Save();
            SceneManager.LoadScene(levelToSwichTo);

        }       
    }
}

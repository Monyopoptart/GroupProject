using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class portal : MonoBehaviour
{
    public string levelToSwichTo;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.GetComponent<PlayerControls>() !=null)
        {
            Score count = FindObjectOfType<Score>();
            PlayerPrefs.SetInt("Score", count.getScore());
            PlayerPrefs.Save();

            SceneManager.LoadScene(levelToSwichTo);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Score : MonoBehaviour
{
    public Text killsText;

    public void SetScore(int newScore)
    {
        count = newScore;
        killsText.text = "Kills: " + count.ToString() + "/10";
    }
    public int getScore()
    {
        return count;
    }

    private int count = 0;

    public void ChangeScore(int change)
    {
        Debug.Log("Test");
        count += change;
        if (killsText)
        {
            killsText.text = "Kills: " + count.ToString() + "/10";
            if (count >= 10) //Win here 
            {
                SceneManager.LoadScene("MainMenu");
            }
        }

    }
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("IN Score Start: " + gameObject.name);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

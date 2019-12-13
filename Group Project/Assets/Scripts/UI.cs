using UnityEngine;
using UnityEngine.UI;


//Phillip worked on this one
public class UI : MonoBehaviour
{
    public GameObject[] hearts;
    public Text scoreText;
    private Globals globals;

    void Start()
    {
        globals = GameObject.FindObjectOfType<Globals>();

        //Invoke("TestUI", 2.0f); // Testing UI
    }

    // Method purely for testing UI elements. Should change them every 2 seconds
    void TestUI()
    {
        globals.changePlayerHealth(-4);
        globals.changePlayerScore(4);
        Invoke("TestUI", 2.0f);
    }

    // DON'T TOUCH UNLESS YOU KNOW WHAT YOU'RE DOING
    // Dynamically changes hearts so they correctly represent the percentage of health left
    // Should work with any number of hearts and any amount of health/maxHealth so we can have permanent health upgrades
    // With 5 hearts and 100 health, each heart would represent 20 HP, and the 5 states on each heart would represent 4 HP each
    public void UpdateHealth(float health, float maxHealth)
    {
        float fractionHealth = maxHealth / hearts.Length; // Gets the fraction of health that each heart will contain
        float heartBase = 0.0f;
        for(int i = 0; i < hearts.Length; ++i)
        {
            hearts[i].GetComponent<Animator>().SetFloat("PercentHealth", (health - heartBase) / fractionHealth); // Passes the percentage of each heart's "fraction" of health on to the animator component to change heart's state
            heartBase += fractionHealth; // Increases each heart's minimum value by the fraction each contains
        }
    }

    public void UpdateScore(float score)
    {
        scoreText.text = "Score: " + score;
    }
}

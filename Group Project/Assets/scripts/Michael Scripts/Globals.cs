using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Globals : MonoBehaviour
{
    private static float playerHealth; //Private because it will need to be changed by public function changePlayerHealth(float change);
    private float maxHealth;
    public GameObject Player; //Insert player prefab here so that we can access public functions.
    //public Slider playerHealthSlider; //Players health will appear with this slider
    // Start is called before the first frame update

    void Start()
    {
        playerHealth = 100; //100 to start
        maxHealth = 100; //100 is max
        

    }

    // Update is called once per frame
    void Update()
    {
        //playerHealthSlider.value = playerHealth / maxHealth; //Changes the slider health. We will move this out of Update() once we have more of our game finished.
        // I made some hearts and animated them. I think it will be more visually appealing than a slider if you guys are okay with using them. -Phillip
        if (returnHealth() < 0 || returnHealth() == 0)
        {
            //Quit();
            // We'll need this to boot the player to a lose screen. I can get win and lose screens done in the next 2 weeks -Phillip
        }
    }

    public void changePlayerHealth(float change) //Public function that can be call by other scripts. 
    {
        playerHealth += change; //health will add change to itself
        Debug.Log("Health is " + returnHealth());
    }

    public static void changePlayerHealthStatic(float change)
    {
        playerHealth += change; //This is a static version of the above function so that we can change the health.
        Debug.Log("Health is " + returnHealth());
    }

    private static float returnHealth() //Static function that allows only this Script to return the player Health
    {
        return playerHealth;
    }
    void Quit() // Exit the application
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
}

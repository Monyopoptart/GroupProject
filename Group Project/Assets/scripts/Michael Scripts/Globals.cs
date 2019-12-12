using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Globals : MonoBehaviour
{
    private static float playerHealth = 100; //Private because it will need to be changed by public function changePlayerHealth(float change);
    private static float maxHealth = 100;
    private static int playerScore = 0;
    private static ushort currentLevel = 1;
    private static ushort maxLevel = 1;
    public GameObject Player; //Insert player prefab here so that we can access public functions.
    public GameObject UICanvas;
    // Start is called before the first frame update

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //playerHealthSlider.value = playerHealth / maxHealth; //Changes the slider health. We will move this out of Update() once we have more of our game finished.
        // I made some hearts and animated them. I think it will be more visually appealing than a slider if you guys are okay with using them. -Phillip
        if (returnHealth() < 0 || returnHealth() == 0)
        {
            if (Player.GetComponent<PlayerControls>() != null)
            {
                Player.GetComponent<PlayerControls>().Respawn();
                playerHealth = 100;
                UICanvas.GetComponent<UI>().UpdateHealth(playerHealth, maxHealth);
            }
            else
            {
                Destroy(gameObject);
            }
        }
    }

    public void resetProgress()
    {
        playerHealth = 100;
        maxHealth = 100;
        playerScore = 0;
        currentLevel = 1;
    }

    public void changePlayerHealth(float change) //Public function that can be call by other scripts. 
    {
        playerHealth += change; //health will add change to itself
        Debug.Log("Health is " + returnHealth());
        if(UICanvas != null)
        {
            UICanvas.GetComponent<UI>().UpdateHealth(playerHealth, maxHealth);
        } else
        {
            Debug.Log("You forgot to hook in the UI Canvas to your Globals script!");
        }
    }

    public void changePlayerScore(int change) //Public function that can be call by other scripts. 
    {
        playerScore += change; //Score will add change to itself
        Debug.Log("Score is " + returnScore());
        if (UICanvas != null)
        {
            UICanvas.GetComponent<UI>().UpdateScore(playerScore);
        }
        else
        {
            Debug.Log("You forgot to hook in the UI Canvas to your Globals script!");
        }
    }

    private static float returnHealth() //Static function that allows only this Script to return the player Health
    {
        return playerHealth;
    }

    private static int returnScore()
    {
        return playerScore;
    }

    public ushort returnCurrentLevel()
    {
        return currentLevel;
    }
    public ushort returnMaxLevel()
    {
        return maxLevel;
    }
    public void unlockAllLevels()
    {
        maxLevel = 4;
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

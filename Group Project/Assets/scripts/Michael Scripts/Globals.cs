using UnityEngine;
using UnityEngine.SceneManagement;

public class Globals : MonoBehaviour
{
    private static float playerHealth = 100;    //Private because it will need to be changed by public function changePlayerHealth(float change);
    private static float maxHealth = 100;
    private static int playerScore = 0;
    private static ushort currentLevel = 1;
    private static ushort maxLevel = 1;         // Maximum level achieved by player
    private static ushort finalLevel = 4;       // Final level in the entire game
    public GameObject Player;                   // Insert player prefab here so that we can access public functions.
    public GameObject UICanvas;

    void Start()
    {
    }

    void Update()
    {
    }

    public void resetProgress()
    {
        playerHealth = 100;
        maxHealth = 100;
        playerScore = 0;
        currentLevel = 1;
        maxLevel = 1;
    }

    public void changePlayerHealth(float change) //Public function that can be call by other scripts. 
    {
        playerHealth += change; //health will add change to itself
        if(playerHealth <= 0)
            SceneManager.LoadScene("LoseScreen");
        if(UICanvas != null)
            UICanvas.GetComponent<UI>().UpdateHealth(playerHealth, maxHealth);
        else
            Debug.Log("You forgot to hook in the UI Canvas to your Globals script!");
        //Debug.Log("Health is " + returnHealth());
    }

    public void changePlayerScore(int change) //Public function that can be call by other scripts. 
    {
        playerScore += change; //Score will add change to itself
        if (UICanvas != null)
            UICanvas.GetComponent<UI>().UpdateScore(playerScore);
        else
            Debug.Log("You forgot to hook in the UI Canvas to your Globals script!");
        //Debug.Log("Score is " + returnScore());
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

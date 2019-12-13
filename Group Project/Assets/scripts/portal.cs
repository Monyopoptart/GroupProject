using UnityEngine;
using UnityEngine.SceneManagement;
//Robert, Michael, and Phillip worked on this a lot
public class portal : MonoBehaviour
{

    ushort thisIstheLevel;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Globals globals = FindObjectOfType<Globals>();
        thisIstheLevel = globals.returnCurrentLevel();

        if (collision.gameObject.tag == "Player")
        {
            if (globals.returnCurrentLevel() == globals.returnFinalLevel())
                SceneManager.LoadScene("GameWin");
            else
            {
                // We can't use the portal to increase the current level because the player might return to a previous level and it will cause issues
                // That is why the level needs to be set at the beginning of a level -Phillip
                //globals.increaseCurrentLevel();
                Debug.Log("You finished level " + thisIstheLevel);
                SceneManager.LoadScene("WinScreen");
            }

        }       
    }
}

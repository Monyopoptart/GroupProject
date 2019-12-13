using UnityEngine;
using UnityEngine.SceneManagement;
//Robert Bunch worked on this
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
                Debug.Log("You finished level " + thisIstheLevel);
                SceneManager.LoadScene("WinScreen");
            }

        }       
    }
}

using UnityEngine;
using UnityEngine.SceneManagement;
//Robert Bunch worked on this
public class Portal : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Globals globals = FindObjectOfType<Globals>();
            if (globals.returnCurrentLevel() == globals.returnFinalLevel())
                SceneManager.LoadScene("GameWin");
            else
                SceneManager.LoadScene("WinScreen");
        }       
    }
}

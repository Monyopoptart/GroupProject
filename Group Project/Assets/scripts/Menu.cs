using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public Button Play; //Place Play button here
    public Button Quit; //Place Quit button here
    // Start is called before the first frame update
    void Start()
    {
        Button PlayBtn = Play.GetComponent<Button>(); //Calls the play button and finds it's Button component
        Button QuitBtn = Quit.GetComponent<Button>();
        PlayBtn.onClick.AddListener(PlayOnClick); //When play is clicked, loads the next scene
        QuitBtn.onClick.AddListener(QuitOnClick);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void PlayOnClick()
    {
        SceneManager.LoadScene("Level1");
    }
    void QuitOnClick()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
}

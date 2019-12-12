using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public Button Play; //Place Play button here
    public Button Level1, Level2, Level3, Level4;
    public Button Quit;
    public Button Credits;
    public Button MainMenu;
    public Button ResetProgress;
    public Button UnlockLevelsCheat;

    // Start is called before the first frame update
    void Start()
    {
        if(Play != null)
        {
            Button PlayBtn = Play.GetComponent<Button>(); //Calls the play button and finds it's Button component
            PlayBtn.onClick.AddListener(PlayOnClick); //When play is clicked, loads the next scene
        }

        if(Level1 != null)
        {
            Button Level1Btn = Level1.GetComponent<Button>();
            Level1Btn.onClick.AddListener(delegate { LoadLevel(1); });

            Button Level2Btn = Level2.GetComponent<Button>();
            Level2Btn.onClick.AddListener(delegate { LoadLevel(2); });

            Button Level3Btn = Level3.GetComponent<Button>();
            Level3Btn.onClick.AddListener(delegate { LoadLevel(3); });

            Button Level4Btn = Level4.GetComponent<Button>();
            Level4Btn.onClick.AddListener(delegate { LoadLevel(4); });

            SetLevelsInteractable();
        }

        if (Quit != null)
        {
            Button QuitBtn = Quit.GetComponent<Button>();
            QuitBtn.onClick.AddListener(QuitOnClick);
        }
        if(Credits != null)
        {
            Button CreditsBtn = Credits.GetComponent<Button>();
            CreditsBtn.onClick.AddListener(CreditsOnClick);
        }
        if(MainMenu != null)
        {
            Button MainMenuBtn = MainMenu.GetComponent<Button>();
            MainMenuBtn.onClick.AddListener(MainMenuOnClick);
        }
        if(ResetProgress != null)
        {
            Button ResetProgressBtn = ResetProgress.GetComponent<Button>();
            ResetProgressBtn.onClick.AddListener(ResetProgressOnClick);
        }
        if(UnlockLevelsCheat != null)
        {
            Button UnlockLvlsBtn = UnlockLevelsCheat.GetComponent<Button>();
            UnlockLvlsBtn.onClick.AddListener(UnlockLevelsOnClick);
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void PlayOnClick()
    {
        SceneManager.LoadScene("LevelSelect");
    }

    void LoadLevel(ushort level)
    {
        SceneManager.LoadScene("Level" + level.ToString());
    }

    void QuitOnClick()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }

    void CreditsOnClick()
    {
        SceneManager.LoadScene("Credits");
    }

    void MainMenuOnClick()
    {
        SceneManager.LoadScene("MainMenu");
    }

    void ResetProgressOnClick()
    {
        GameObject.FindObjectOfType<Globals>().resetProgress();
        if (Level1 != null)
            SetLevelsInteractable();

    }

    void UnlockLevelsOnClick()
    {
        GameObject.FindObjectOfType<Globals>().unlockAllLevels();
        if(Level1 != null)
            SetLevelsInteractable();
    }

    void SetLevelsInteractable()
    {
        ushort maxLvl = GameObject.FindObjectOfType<Globals>().returnMaxLevel();
        switch (maxLvl)
        {
            case 1:
                Level2.interactable = false;
                goto case 2;
            case 2:
                Level3.interactable = false;
                goto case 3;
            case 3:
                Level4.interactable = false;
                break;
        }
    }
}

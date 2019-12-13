using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public Text ScoreText;
    public Button LevelSelect; //Place Play button here
    public Button Level1, Level2, Level3, Level4;
    public Button Quit;
    public Button Credits;
    public Button MainMenu;
    public Button ResetProgress;
    public Button UnlockLevelsCheat;
    public Button RestartCurrLevel;
    public Button NextLevel;

    // Start is called before the first frame update
    void Start()
    {
        if(ScoreText != null)
            ScoreText.text = "Score: " + GameObject.FindObjectOfType<Globals>().returnScore();

        if(LevelSelect != null)
            LevelSelect.GetComponent<Button>().onClick.AddListener(PlayOnClick);

        if(Level1 != null)
        {
            Level1.GetComponent<Button>().onClick.AddListener(delegate { LoadLevel(1); });
            Level2.GetComponent<Button>().onClick.AddListener(delegate { LoadLevel(2); });
            Level3.GetComponent<Button>().onClick.AddListener(delegate { LoadLevel(3); });
            Level4.GetComponent<Button>().onClick.AddListener(delegate { LoadLevel(4); });

            SetLevelsInteractable();
        }

        if (Quit != null)
            Quit.GetComponent<Button>().onClick.AddListener(QuitOnClick);

        if(Credits != null)
            Credits.GetComponent<Button>().onClick.AddListener(CreditsOnClick);

        if(MainMenu != null)
            MainMenu.GetComponent<Button>().onClick.AddListener(MainMenuOnClick);

        if(ResetProgress != null)
            ResetProgress.GetComponent<Button>().onClick.AddListener(ResetProgressOnClick);

        if(UnlockLevelsCheat != null)
            UnlockLevelsCheat.GetComponent<Button>().onClick.AddListener(UnlockLevelsOnClick);

        if(RestartCurrLevel != null)
            RestartCurrLevel.GetComponent<Button>().onClick.AddListener(delegate { LoadLevel(GameObject.FindObjectOfType<Globals>().returnCurrentLevel()); });

        if(NextLevel != null)
        {
            ushort level = GameObject.FindObjectOfType<Globals>().returnCurrentLevel();
            NextLevel.GetComponent<Button>().onClick.AddListener(delegate { LoadLevel(++level); });
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
        SceneManager.LoadScene("Level" + level);
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
        // Sets which levels aren't interactable
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
        // Sets which levels ARE interactable
        switch (maxLvl)
        {
            case 4:
                Level4.interactable = true;
                goto case 3;
            case 3:
                Level3.interactable = true;
                goto case 2;
            case 2:
                Level2.interactable = true;
                break;
        }
    }
}


using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneFlowManager : MonoBehaviour
{
    
    public GameObject mainMenuPanel;
    public GameObject cutscenePanel;
    public GameObject instructionsPanel;
    private bool playClicked=false;


    void Start()//remove this before build
    {
        PlayerPrefs.DeleteKey("HasWatchedCutscene");
    }

     // PLAY BUTTON
    public void PlayGame()
    {
        playClicked = true;

        mainMenuPanel.SetActive(false);

        if (PlayerPrefs.GetInt("HasWatchedCutscene", 0) == 0)
        {
            cutscenePanel.SetActive(true);
        }
        else
        {
            instructionsPanel.SetActive(true);
        }
    }

    // SKIP BUTTON
    public void SkipCutscene()
    {
        FinishCutscene();
    }

    // WHEN CUTSCENE FINISHES
    public void FinishCutscene()
    {
        PlayerPrefs.SetInt("HasWatchedCutscene", 1);
        PlayerPrefs.Save();

        cutscenePanel.SetActive(false);
        instructionsPanel.SetActive(true);
    }

    // INSTRUCTIONS ICON
    public void OpenInstructions()
    {
        playClicked = false;

        mainMenuPanel.SetActive(false);
        instructionsPanel.SetActive(true);
    }

    // OKAY BUTTON
    public void CloseInstructions()
    {
        instructionsPanel.SetActive(false);

        if (playClicked)
        {
            StartLevel();
        }
        else
        {
            mainMenuPanel.SetActive(true);
        }
    }

    // START GAME BUTTON
    public void StartLevel()
    {
        SceneManager.LoadScene("Level1");
    }
}
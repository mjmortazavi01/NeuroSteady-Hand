using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelUIManager : MonoBehaviour
{

    public GameObject endOfLevelPanel;
    public Text resultsText;
    

    public Text testStatusText; 

    void Start()
    {

        if (endOfLevelPanel != null)
            endOfLevelPanel.SetActive(false);


        if (!GameModeManager.IsPracticeMode && TestManager.instance != null)
        {
            int level = TestManager.instance.GetCurrentLevel();
            int trial = TestManager.instance.GetCurrentTrial();
            testStatusText.text = "Level: " + level + " | Trial: " + trial + " / 5";
        }
        else
        {

            testStatusText.gameObject.SetActive(false);
        }
    }
    

    public void ShowEndOfLevelPanel(float time, int collisions)
    {
        endOfLevelPanel.SetActive(true);
        resultsText.text = "Time: " + time.ToString("F2") + "\nCollisions: " + collisions;
    }


    public void RestartLevel()
    {

        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void BackToMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}



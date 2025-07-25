using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{

    public GameObject instructionsPanel;
    public GameObject levelSelectPanel;
    public GameObject questionnairePanel;


    public InputField idInput;
    public InputField ageInput;
    public InputField sessionInput;
    public Dropdown conditionDropdown;

    public string level1SceneName = "Level_01"; 



    public void ShowInstructionsPanel()
    {
        instructionsPanel.SetActive(true);
    }
    

    public void ShowQuestionnairePanel()
    {
        instructionsPanel.SetActive(false);
        questionnairePanel.SetActive(true);
    }

    public void ShowLevelSelectPanel()
    {
        levelSelectPanel.SetActive(true);
    }

    public void HideAllPanels()
    {
        instructionsPanel.SetActive(false);
        levelSelectPanel.SetActive(false);
        questionnairePanel.SetActive(false);
    }

    public void StartGameFromQuestionnaire()
    {

        if (string.IsNullOrEmpty(idInput.text) || string.IsNullOrEmpty(ageInput.text) || string.IsNullOrEmpty(sessionInput.text))
        {
            Debug.LogWarning("Please fill out all required fields.");
            return; 
        }


        ParticipantData.participantID = idInput.text;
        int.TryParse(ageInput.text, out ParticipantData.age);
        int.TryParse(sessionInput.text, out ParticipantData.sessionNumber);
        
        ParticipantData.handUsed = "Not Specified";

        ParticipantData.condition = conditionDropdown.options[conditionDropdown.value].text;

        GameModeManager.IsPracticeMode = false;
        
        if (TestManager.instance != null)
        {
            TestManager.instance.StartTestFlow();
        }
        else
        {
            Debug.LogError("TestManager instance not found!");
        }
    }


    public void LoadLevel_1()
    {
        GameModeManager.IsPracticeMode = true;
        SceneManager.LoadScene("Level_01");
    }

    public void LoadLevel_2()
    {
        GameModeManager.IsPracticeMode = true;
        SceneManager.LoadScene("Level_02");
    }

    public void LoadLevel_3()
    {
        GameModeManager.IsPracticeMode = true;
        SceneManager.LoadScene("Level_03");
    }

    public void LoadLevel_4()
    {
        GameModeManager.IsPracticeMode = true;
        SceneManager.LoadScene("Level_04");
    }

    public void LoadLevel_5()
    {
        GameModeManager.IsPracticeMode = true;
        SceneManager.LoadScene("Level_05");
    }


    public void QuitGame()
    {
        Debug.Log("Quitting game...");
        Application.Quit();
    }
}

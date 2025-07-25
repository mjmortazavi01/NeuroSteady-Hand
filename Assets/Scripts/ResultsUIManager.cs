using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ResultsUIManager : MonoBehaviour
{
    [Header("UI Texts for Results")]
    public Text level1ResultsText;
    public Text level2ResultsText;
    public Text level3ResultsText;
    public Text level4ResultsText;
    public Text level5ResultsText;


    void Start()
    {
        DisplayResults();
    }

    void DisplayResults()
    {

        if (TestManager.instance == null)
        {
            Debug.LogError("TestManager instance not found! Cannot display results.");

            level1ResultsText.text = "Error: No test data found.";
            return;
        }

        level1ResultsText.text = GetResultStringForLevel(1);
        level2ResultsText.text = GetResultStringForLevel(2);
        level3ResultsText.text = GetResultStringForLevel(3);
        level4ResultsText.text = GetResultStringForLevel(4);
        level5ResultsText.text = GetResultStringForLevel(5);
    }


    private string GetResultStringForLevel(int level)
    {

        float avgTime = TestManager.instance.GetAverageTimeForLevel(level);
        float avgCollisions = TestManager.instance.GetAverageCollisionsForLevel(level);


        return "Level " + level + ":  Avg Time = " + avgTime.ToString("F2") + "s  |  Avg Collisions = " + avgCollisions.ToString("F1");
    }

    public void BackToMainMenu()
    {
        if (TestManager.instance != null)
        {
            Destroy(TestManager.instance.gameObject);
        }
        
        SceneManager.LoadScene("MainMenu");
    }
}

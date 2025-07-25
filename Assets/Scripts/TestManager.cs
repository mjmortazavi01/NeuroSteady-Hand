using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections.Generic;
using System.Linq;

public class TrialResult
{
    public int level;
    public int trial;
    public float time;
    public int collisions;
}

public class TestManager : MonoBehaviour
{
    public static TestManager instance;

    public int totalLevels = 5;
    public int trialsPerLevel = 5;

    private int currentLevel = 1;
    private int currentTrial = 1;

    public List<TrialResult> allTrialResults = new List<TrialResult>();

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void StartTestFlow()
    {
        DataLogger.currentFilePath = null;

        currentLevel = 1;
        currentTrial = 1;
        allTrialResults.Clear();
        LoadCurrentTestScene();
    }

    public void TrialCompleted(float time, int collisions)
    {
        allTrialResults.Add(new TrialResult
        {
            level = currentLevel,
            trial = currentTrial,
            time = time,
            collisions = collisions
        });

        currentTrial++;

        if (currentTrial > trialsPerLevel)
        {
            currentTrial = 1;
            currentLevel++;
        }

        if (currentLevel > totalLevels)
        {
            SceneManager.LoadScene("ResultsScene"); 
        }
        else
        {
            LoadCurrentTestScene();
        }
    }

    private void LoadCurrentTestScene()
    {
        string sceneName = "Level_" + currentLevel.ToString("D2");
        SceneManager.LoadScene(sceneName);
    }

    public int GetCurrentLevel() => currentLevel;
    public int GetCurrentTrial() => currentTrial;

    public float GetAverageTimeForLevel(int level)
    {
        var levelResults = allTrialResults.Where(r => r.level == level);
        if (levelResults.Any())
            return (float)levelResults.Average(r => r.time);
        return 0f;
    }

    public float GetAverageCollisionsForLevel(int level)
    {
        var levelResults = allTrialResults.Where(r => r.level == level);
        if (levelResults.Any())
            return (float)levelResults.Average(r => r.collisions);
        return 0f;
    }
}
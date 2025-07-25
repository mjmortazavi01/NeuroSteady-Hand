using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public int collisionCount = 0;
    public float gameTime = 0f;
    public bool isGameActive = false;

    public Text collisionText;
    public Text timeText;


    private LevelUIManager levelUIManager;
    private DataLogger dataLogger;

    void Awake()
    {
        instance = this;
        levelUIManager = FindObjectOfType<LevelUIManager>();
        dataLogger = GetComponent<DataLogger>();
    }

    void Update()
    {
        if (isGameActive)
        {
            gameTime += Time.deltaTime;
            timeText.text = "Time: " + gameTime.ToString("F2");
        }
    }

    public void IncrementCollision()
    {
        if (isGameActive)
        {
            collisionCount++;
            collisionText.text = "Collisions: " + collisionCount.ToString();
        }
    }

    public void StartGame()
    {
        isGameActive = true;
        gameTime = 0f;
        collisionCount = 0;
        collisionText.text = "Collisions: 0";
        timeText.text = "Time: 0.00";
    }

    public void EndGame()
    {
        isGameActive = false;
        

        if (GameModeManager.IsPracticeMode)
        {

            if (levelUIManager != null)
            {
                levelUIManager.ShowEndOfLevelPanel(gameTime, collisionCount);
            }
        }
        else
        {

            if (dataLogger != null && TestManager.instance != null)
            {
                dataLogger.LogData(
                    ParticipantData.participantID,
                    ParticipantData.age,
                    ParticipantData.handUsed,
                    ParticipantData.condition,
                    ParticipantData.sessionNumber,
                    TestManager.instance.GetCurrentLevel(),
                    TestManager.instance.GetCurrentTrial(),
                    gameTime,
                    collisionCount
                );
            }


            if (TestManager.instance != null)
            {
                TestManager.instance.TrialCompleted(gameTime, collisionCount);
            }
        }
    }
}

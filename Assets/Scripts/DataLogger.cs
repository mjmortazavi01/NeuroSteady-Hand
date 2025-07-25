using UnityEngine;
using System.IO;

public class DataLogger : MonoBehaviour
{
    
    public static string currentFilePath;

    void Awake()
    {
        if (string.IsNullOrEmpty(currentFilePath))
        {
            
            string fileName = ParticipantData.participantID + "_" + ParticipantData.sessionNumber + ".csv";
            
            
            currentFilePath = Path.Combine(Application.persistentDataPath, fileName);

            Debug.Log("Creating new data log file at: " + currentFilePath);

            
            string header = "ParticipantID,Age,HandUsed,Condition,Session,Level,Trial,Time,Collisions\n";
            File.WriteAllText(currentFilePath, header);
        }
    }


    public void LogData(string playerID, int age, string hand, string condition, int session, int level, int trial, float time, int collisions)
    {
        string data = string.Format("{0},{1},{2},{3},{4},{5},{6},{7},{8}\n", 
                                    playerID, age, hand, condition, session, level, trial, time.ToString("F2"), collisions);


        File.AppendAllText(currentFilePath, data);
    }
}
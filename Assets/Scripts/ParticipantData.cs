using UnityEngine;

public static class ParticipantData
{
    public static string participantID = "Default_ID";
    public static int age = 0;
    public static string handUsed = "Not Set";
    public static string condition = "Not Set";
    public static int sessionNumber = 1;


    public static void Reset()
    {
        participantID = "Default_ID";
        age = 0;
        handUsed = "Not Set";
        condition = "Not Set";
        sessionNumber = 1;
    }
}


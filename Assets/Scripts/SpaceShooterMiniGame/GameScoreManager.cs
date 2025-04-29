using System.IO;
using UnityEngine;

public static class GameScoreManager
{
    private static readonly string FilePath = Path.Combine(Application.persistentDataPath, "scores.json");
    private static ScoreData scoreData;
    static GameScoreManager()
    {
        LoadScores();
    }

    public static void SaveScore(int score)
    {
        if (scoreData == null)
        {
            scoreData = new ScoreData();
        }

        scoreData.highScore = Mathf.Max(scoreData.highScore, score);

        string json = JsonUtility.ToJson(scoreData, true);
        File.WriteAllText(FilePath, json);
        Debug.Log($"Score sauvegardé : {scoreData.highScore}");
    }

    public static int GetHighScore()
    {
        return scoreData != null ? scoreData.highScore : 0;
    }

    private static void LoadScores()
    {
        if (File.Exists(FilePath))
        {
            string json = File.ReadAllText(FilePath);
            scoreData = JsonUtility.FromJson<ScoreData>(json);
            Debug.Log($"Score chargé : {scoreData.highScore}");
        }
        else
        {
            scoreData = new ScoreData();
        }
    }
    public static void ResetScores()
    {
        if (scoreData == null)
        {
            scoreData = new ScoreData();
        }

        scoreData.highScore = 0;

        string json = JsonUtility.ToJson(scoreData, true);
        File.WriteAllText(FilePath, json);

        Debug.Log("Score réinitialisé à 0.");
    }
}
    [System.Serializable]
public class ScoreData
{
    public int highScore = 0;
}
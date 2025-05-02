using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    private static ScoreManager instance;

    List<int> result = new List<int>() { 0, 0, 0 };
    public TextMeshProUGUI resultat;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
            return;
        }

        ShowScore();
    }

    public void AddScore(int score, int index)
    {
        result[index] += score;
    }

    public void ShowScore()
    {
        if (resultat != null)
        {
            resultat.text = $"Space Shooter : {result[0]} \nRun In The Forest : {result[1]} \nHide And Seek : {result[2]}";
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    List<int> result = new List<int>() { 0, 0, 0 };
    public TextMeshProUGUI resultat;

    public void Awake()
    {
        showScore();
    }
    public void addScore(int score, int index)
    {
        result[index] += score;
    }

    public void showScore()
    {
        resultat.text = $"Space Shooter : {result[0]} \nRun In The Forest : {result[1]} \nHide And Seek : {result[2]}";
    }
}
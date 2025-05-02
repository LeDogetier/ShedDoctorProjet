using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MiniGameManager : MonoBehaviour
{
    public static MiniGameManager Instance;

    private int asteroidsDestroyed = 0;  
    private bool gameEnded = false;     
    public GameObject victoryCanvas;    
    public GameObject defeatCanvas;  
    public ScoreManager scoreManager;
    

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }


    public void AsteroidDestroyed()
    {
        if (gameEnded) return; 

        asteroidsDestroyed++;
        Debug.Log($"Astéroïdes détruits : {asteroidsDestroyed}");
        CheckGameEndCondition();
    }

    
    public void PlayerHit()
    {
        if (gameEnded) return; 
        TriggerDefeat();
    }


    public void CheckGameEndCondition()
    {
        int asteroidsRemaining = GameObject.FindGameObjectsWithTag("Asteroide").Length-1;

        Debug.Log($"Astéroïdes restants : {asteroidsRemaining}, Astéroïdes détruits : {asteroidsDestroyed}");

        if (asteroidsRemaining == 0)
        {
            if (asteroidsDestroyed >= 6)
            {
                TriggerVictory();
            }
            else
            {
                TriggerDefeat();
            }
        }
    }
    private void TriggerVictory()
    {
        if (gameEnded) return;

        Debug.Log("Victoire déclenchée !");
        gameEnded = true;

        int finalScore = asteroidsDestroyed;
        //scoreManager.AddScore(finalScore, 0);
        Debug.Log($"Score final : {finalScore}");

        GameScoreManager.SaveScore(finalScore); 

        if (victoryCanvas != null)
        {
            victoryCanvas.SetActive(true);
            TextMeshProUGUI highScoreText = victoryCanvas.GetComponentInChildren<TextMeshProUGUI>();
            if (highScoreText != null)
            {
                highScoreText.text = $"Victory! \n\n High Score : {GameScoreManager.GetHighScore()}";
            }
        }
        else
        {
            Debug.LogError("VictoryCanvas n'est pas assigné !");
        }
        Time.timeScale = 0;
    }

    public void TriggerDefeat()
    {
        if (gameEnded) return; 

        Debug.Log("Défaite déclenchée : le joueur a été touché ou pas assez d'astéroïdes détruits.");
        gameEnded = true;

        if (defeatCanvas != null)
        {
            defeatCanvas.SetActive(true); 
        }
        else
        {
            Debug.LogError("DefeatCanvas n'est pas assigné !");
        }
        Time.timeScale = 0; 
    }
}
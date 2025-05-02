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
        Debug.Log($"Ast�ro�des d�truits : {asteroidsDestroyed}");
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

        Debug.Log($"Ast�ro�des restants : {asteroidsRemaining}, Ast�ro�des d�truits : {asteroidsDestroyed}");

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

        Debug.Log("Victoire d�clench�e !");
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
            Debug.LogError("VictoryCanvas n'est pas assign� !");
        }
        Time.timeScale = 0;
    }

    public void TriggerDefeat()
    {
        if (gameEnded) return; 

        Debug.Log("D�faite d�clench�e : le joueur a �t� touch� ou pas assez d'ast�ro�des d�truits.");
        gameEnded = true;

        if (defeatCanvas != null)
        {
            defeatCanvas.SetActive(true); 
        }
        else
        {
            Debug.LogError("DefeatCanvas n'est pas assign� !");
        }
        Time.timeScale = 0; 
    }
}
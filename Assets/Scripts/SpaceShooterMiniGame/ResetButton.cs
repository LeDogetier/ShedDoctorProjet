using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetButton : MonoBehaviour
{
    public void ResetHighScore()
    {
        GameScoreManager.ResetScores(); 
        Debug.Log("Bouton de r�initialisation du score utilis� !");
    }
}

using TMPro;
using UnityEngine;

public class ScoreDisplay : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI scoreText;

    void Start()
    {
        var scoreManager = FindObjectOfType<ScoreManager>();
        if (scoreManager != null && scoreText != null)
        {
            scoreManager.SetResultText(scoreText);
        }
    }
    void OnEnable()
    {
        var scoreManager = FindObjectOfType<ScoreManager>();
        scoreManager?.ShowScore();
    }

}


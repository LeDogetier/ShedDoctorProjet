using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public GameObject GameOverUI;
    public GameObject GameWinUI;
    public GameObject GameLoseUI;

    public void ShowGameOverUI()
    {
        if (GameOverUI != null)
        {
            GameOverUI.SetActive(true);
            Time.timeScale = 0f;
            Debug.Log("GameOver");
        }
    }
    public void ShowGameWinUI()
    {
        if (GameWinUI != null)
        {
            GameWinUI.SetActive(true);
            Time.timeScale = 0f;
            Debug.Log("Win");
        }
    }
    public void ShowGameLoseUI()
    {
        if (GameWinUI != null)
        {
            GameLoseUI.SetActive(true);
            Time.timeScale = 0f;
            Debug.Log("Lose");
        }
    }

    public void ReturnToMenu()
    {
        SceneManager.LoadScene("MainScene");
    }
}

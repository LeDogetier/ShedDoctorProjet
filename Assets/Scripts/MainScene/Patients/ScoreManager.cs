using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;


public class ScoreManager : MonoBehaviour
{
    private static ScoreManager instance;

    List<int> result = new List<int>() { 0, 0, 0 };
    public TextMeshProUGUI resultat;

    /*private void Start()
    {
        TextMeshProUGUI found = null;

        foreach (var tmp in FindObjectsOfType<TextMeshProUGUI>())
        {
            if (tmp.CompareTag("Resultat"))
            {
                found = tmp;
                break;
            }
        }

        if (found == null)
        {
            found = FindObjectOfType<TextMeshProUGUI>();
        }

        resultat = found;
        ShowScore();
    }*/




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

    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        StartCoroutine(ReassignResultatNextFrame());
    }

    private System.Collections.IEnumerator ReassignResultatNextFrame()
    {

        yield return null;

        Debug.Log("[ScoreManager] Rebinding TMP after scene load...");

        resultat = null;

        foreach (var tmp in FindObjectsOfType<TextMeshProUGUI>())
        {
            if (tmp.CompareTag("Resultat"))
            {
                resultat = tmp;
                break;
            }
        }

        if (resultat == null)
        {
            resultat = FindObjectOfType<TextMeshProUGUI>();
        }

        ShowScore();
    }



    public void AddScore(int score, int index)
    {
        result[index] += score;
    }

    public void ShowScore()
    {
        if (resultat == null) return;

        string text = "";
        text += $"Space Shooter : {result[0]}\n";
        text += $"Run In The Forest : {result[1]}\n";
        text += $"Hide And Seek : {result[2]}\n";

        if (string.IsNullOrEmpty(text)) text = "Aucun score pour l'instant.";

        resultat.text = text;
    }


    public void SetResultText(TextMeshProUGUI textComponent)
    {
        resultat = textComponent;
        ShowScore();
    }

}

using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StoryManager : MonoBehaviour
{
    public TextMeshProUGUI storyText;
    [SerializeField] private GameObject storyCanvas;
    [SerializeField] private GameObject interactHint;

    private Dictionary<int, string> storyScreens = new Dictionary<int, string>
    {
        { 0, "Au fond de la for�t, un vieux cabanon t�attend..." },
        { 1, "Ici, loin de tout, tu es le dernier espoir des �mes �gar�es." },
        { 2, "Peu d��quipements. Beaucoup de volont�. Ton m�tier : gu�rir." },
        { 3, "Chaque patient cache une histoire... � toi de la d�couvrir." }
    };

    private Dictionary<int, string> miniGameIntroScreens = new Dictionary<int, string>
    {
        { 0, "Un villageois est tomb� gravement malade en pleine for�t.\nSeul toi, docteur du cabanon, peux lui venir en aide." },
        { 1, "Le temps presse. S'il reste seul trop longtemps, il n'y survivra pas." },
        { 2, "Prends ton sac, traverse la for�t, et retrouve-le avant qu�il ne soit trop tard." }
    };

    private int currentStoryIndex = 0;
    private bool storyFinished = false;
    private bool isStartingMiniGame = false;
    private string nextSceneName;

    private void Start()
    {

    }

    private void Update()
    {
        if (!storyFinished && Input.GetMouseButtonDown(0))
        {
            NextStoryScreen();
        }
    }

    public void StartMiniGameIntro(string sceneName)
    {
        if (storyCanvas != null)
        {
            storyCanvas.SetActive(true);
        }
        isStartingMiniGame = true;
        nextSceneName = sceneName;
        currentStoryIndex = -1;
        storyFinished = false;
    }
    public void ShowFirstMiniGameIntroScreen()
    {
        if (miniGameIntroScreens.ContainsKey(0))
        {
            currentStoryIndex = 0;
            ShowMiniGameIntroScreen(currentStoryIndex);
        }
    }
    public void NextStoryScreen()
    {
        currentStoryIndex++;
        if (!isStartingMiniGame && storyScreens.ContainsKey(currentStoryIndex))
        {
            ShowCurrentStoryScreen();
        }
        else if (isStartingMiniGame && miniGameIntroScreens.ContainsKey(currentStoryIndex))
        {
            ShowMiniGameIntroScreen(currentStoryIndex);
        }
        else
        {
            if (isStartingMiniGame && !string.IsNullOrEmpty(nextSceneName))
            {
                try
                {
                    SceneManager.LoadScene("RunInTheForest");
                }
                catch (System.Exception e)
                {
                    Debug.LogError($"Failed to load scene '{nextSceneName}': {e.Message}");
                }
            }
            else
            {
                if (storyCanvas != null)
                {
                    storyCanvas.SetActive(false);
                }
            }
            storyFinished = true;
        }
    }

    private void ShowCurrentStoryScreen()
    {
        if (storyText != null && storyScreens.ContainsKey(currentStoryIndex))
        {
            storyText.text = storyScreens[currentStoryIndex] + "\n\n(Cliquer pour continuer)";
        }
    }

    private void ShowMiniGameIntroScreen(int index)
    {
        if (storyText != null && miniGameIntroScreens.ContainsKey(index))
        {
            storyText.text = miniGameIntroScreens[index] + "\n\n(Cliquer pour continuer)";
        }
    }

    public void ShowInteractHint(bool show)
    {
        if (interactHint != null)
        {
            interactHint.SetActive(show);
        }
    }
}
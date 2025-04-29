using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneStart : MonoBehaviour
{
    private bool isPlayerInRange = false;
    [SerializeField] private string sceneToLoad;
    [SerializeField] private StoryManager storyManager;

    private bool hasTriggeredStory = false;

    void Update()
    {
        if (isPlayerInRange && Input.GetKeyDown(KeyCode.E) && !hasTriggeredStory)
        {
            StartStoryBeforeScene();
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerInRange = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerInRange = false;
        }
    }

    private void StartStoryBeforeScene()
    {
        if (storyManager != null && !string.IsNullOrEmpty(sceneToLoad))
        {
            hasTriggeredStory = true;
            storyManager.StartMiniGameIntro(sceneToLoad);
            storyManager.ShowFirstMiniGameIntroScreen();
        }
    }
}
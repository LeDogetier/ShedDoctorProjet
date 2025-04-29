using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ZombieInteract : MonoBehaviour
{
    private bool isPlayerCloseEnough = false;
    [SerializeField] private StoryManager storyManager;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player is colse enough to interact");
            isPlayerCloseEnough = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player exited the range to interact");
            isPlayerCloseEnough = false;
        }
    }
    private void OnMouseDown()
    {  
        if (isPlayerCloseEnough == true)
        {
            SceneManager.LoadScene("HideNSeek");
        }
        else
        {
            Debug.Log("Player is not close enough to interact");
        }
       
    }
}

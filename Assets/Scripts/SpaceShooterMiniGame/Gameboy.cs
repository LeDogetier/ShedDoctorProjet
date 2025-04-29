using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Gameboy : MonoBehaviour
{
    private bool isPlayerInRange = false; 
    //[SerializeField] private string sceneToLoad;

    void Update()
    {
        if (isPlayerInRange && Input.GetKeyDown(KeyCode.E))
        {            
            LoadScene(); 
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

    private void LoadScene()
    {
        SceneManager.LoadScene(2);
        //if (!string.IsNullOrEmpty(sceneToLoad))
        //{
        //    
        //}
    }
}
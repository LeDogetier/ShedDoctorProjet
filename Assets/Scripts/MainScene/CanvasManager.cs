using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasManager : MonoBehaviour
{
    public static CanvasManager Instance { get; private set; }

    public Canvas mainCanvas; 

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject); 
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject); 
    }

    public void ShowImage(GameObject image)
    {
        image.SetActive(true); 
    }

    public void HideImage(GameObject image)
    {
        image.SetActive(false); 
    }
}

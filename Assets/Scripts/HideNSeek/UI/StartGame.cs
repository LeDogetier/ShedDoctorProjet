/*using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class StartGame : MonoBehaviour
{
    [SerializeField] private Button button;
    public bool isGameRunning = false;
    [SerializeField] private DropdownManager dropdownManager;

    private void Start()
    {
        if (button != null)
        {
            button.onClick.AddListener(OnButtonClick);
        }
    }

    private void OnButtonClick()
    {
        isGameRunning = true;
        Debug.Log("Game is running ! ");
        
    }
}*/
using UnityEngine;
using UnityEngine.UI;

public class StartGame : MonoBehaviour
{
    [SerializeField] private Button button;
    [SerializeField] private GameObject menuUI;
    [SerializeField] private GameObject player;
    [SerializeField] private Transform spawnPoint;

    public bool isGameRunning = false;

    private void Start()
    {
        Time.timeScale = 1f;

        if (button != null)
        {
            button.onClick.AddListener(OnButtonClick);
        }

        isGameRunning = false;
    }


    private void OnButtonClick()
    {
        isGameRunning = true;
        Debug.Log("Game is running!");

        if (menuUI != null)
            menuUI.SetActive(false);

        if (player != null && spawnPoint != null)
        {
            player.transform.position = spawnPoint.position;
            player.SetActive(true);
        }
    }
}


using System.Collections;
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
}

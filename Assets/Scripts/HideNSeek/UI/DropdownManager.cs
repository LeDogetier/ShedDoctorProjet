using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class DropdownManager : MonoBehaviour
{
    [SerializeField] private TMP_Dropdown dropdown;
    public int DifficultyLevel;

    private void Start()
    {
        Debug.Log($"Default difficulty : {DifficultyLevel}");
        if (dropdown != null)
        {
            dropdown.onValueChanged.AddListener(OnDropdownValueChanged);

            HandleDefaultValue();
        }
        else
        {
            Debug.LogError("DropDown is null");
        }
    }

    private void OnDropdownValueChanged(int value)
    {
        switch (value)
        {
            case 0:
                DifficultyLevel = 1;
                Debug.Log($"Easy mode : {DifficultyLevel}");
                break;
            case 1:
                DifficultyLevel = 2;
                Debug.Log($"Medium mode : {DifficultyLevel}");
                break;
            case 2:
                DifficultyLevel = 3;
                Debug.Log($"Hard mode : {DifficultyLevel}");
                break;
            default:
                Debug.Log("Unknown Option");
                break;
        }
    }

    private void HandleDefaultValue()
    {
        int defaultValue = dropdown.value;
        OnDropdownValueChanged(defaultValue);
    }

    //public void OnDestroy()
    //{
    //    if (dropdown != null)
    //    {
    //        dropdown.onValueChanged.RemoveListener(OnDropdownValueChanged);
    //    }
    //}
}

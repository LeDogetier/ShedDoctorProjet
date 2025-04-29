using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DifficultyManager : MonoBehaviour, IDifficultyState
{
    private int numberOfItemsToFind;
    private float timeRemaining;
    public int NumberOfItemsToFind {  get { return numberOfItemsToFind; } set {numberOfItemsToFind = value; } }
    public float TimeRemaining { get { return timeRemaining; } set { timeRemaining = value; } }

    [SerializeField] private DropdownManager dropdownManager;

    [SerializeField] private StartGame startGame;

    public bool isGameManagerSetup = false;

    private void Update()
    {
        if (startGame != null && startGame.isGameRunning == true && isGameManagerSetup == false)
        {
            Debug.Log("Setting Up GameManager");

            if (dropdownManager.DifficultyLevel == 1)
            {
                AdjustDifficulty(EnumDifficulty.NORMAL);
                Debug.Log($"Game Difficulty set to normal : Items To Find = {NumberOfItemsToFind} Time allowed = {TimeRemaining}");
            }
            if (dropdownManager.DifficultyLevel == 2)
            {
                AdjustDifficulty(EnumDifficulty.MEDIUM);
                Debug.Log($"Game Difficulty set to medium : Items To Find = {NumberOfItemsToFind} Time allowed = {TimeRemaining}");
            }
            if (dropdownManager.DifficultyLevel == 3)
            {
                AdjustDifficulty(EnumDifficulty.HARD);
                Debug.Log($"Game Difficulty set to hard : Items To Find = {NumberOfItemsToFind} Time allowed = {TimeRemaining}");
            }
            Debug.Log($"NB Of Items : {numberOfItemsToFind}, Time Allowed : {TimeRemaining}");

            isGameManagerSetup = true;

        }
        

       
    }

    public void AdjustDifficulty(EnumDifficulty difficulty)
    {
        switch (difficulty)
        {     
            case EnumDifficulty.NORMAL:
                NumberOfItemsToFind = 1;
                TimeRemaining = 30f;
                break;
            case EnumDifficulty.MEDIUM:
                NumberOfItemsToFind = 3;
                TimeRemaining = 60f;
                break;
            case EnumDifficulty.HARD:
                NumberOfItemsToFind = 5;
                TimeRemaining = 75f;
                break;
        }
    }
}

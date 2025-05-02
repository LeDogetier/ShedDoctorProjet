using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ValidateObject : MonoBehaviour
{
    private ObjectHolder objectHolder;
    private DifficultyManager difficultyManager;
    private EndingManager endingManager;
    public ScoreManager scoreManager;

    

    private void Start()
    {
        objectHolder = GameObject.FindFirstObjectByType<ObjectHolder>();

        GameObject[] managers = GameObject.FindGameObjectsWithTag("Manager");

        foreach (GameObject obj in managers)
        {
            if (difficultyManager == null)
            {
                difficultyManager = obj.GetComponent<DifficultyManager>();
            }

            if (endingManager == null)
            {
                endingManager = obj.GetComponent<EndingManager>();
            }

            if (difficultyManager != null && endingManager != null)
            {
                break;
            }
        }
    }

    private void OnMouseDown()
    {
        Debug.Log("Length of object to find" + objectHolder.ToolsToFind.Count);
        if (objectHolder != null)
        {
                Debug.Log("You found the : " + gameObject.name);
                endingManager.ItemFound++;

                Debug.Log("You found : " + endingManager.ItemFound + "/" + objectHolder.ToolsToFind.Count + " objects");
                Destroy(gameObject);
                scoreManager.AddScore(1, 3);
        }
        else
        {
            Debug.LogWarning("ObjectHolder is not assigned");
        }
    }
}

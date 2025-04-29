using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AssignToolsToHidingSpot : MonoBehaviour
{
    private ObjectHolder objectHolder = null;

    private HidingSpotsHolder hidingSpotsHolder = null;

    public void Initialize()
    {
        GameObject[] holders = GameObject.FindGameObjectsWithTag("Holder");

        foreach (GameObject obj in holders)
        {
            if (objectHolder == null)
            {
                objectHolder = obj.GetComponent<ObjectHolder>();
            }

            if (hidingSpotsHolder == null)
            {
                hidingSpotsHolder = obj.GetComponent<HidingSpotsHolder>();
            }

            if (objectHolder != null && hidingSpotsHolder != null)
            {
                break;
            }
        }

        if (objectHolder != null && hidingSpotsHolder != null)
        {
            Debug.Log("Both Holders were found");
        }
        else
        {
            Debug.LogWarning("Not Found");
        }

       
    }
    public void AssociateObjectToNewPosition(List<GameObject> gameObjects, List<Transform> positions)
    {
        Debug.Log("Comparing");
        for (int i = 0; i < gameObjects.Count; i++)
        {
            if (gameObjects[i] != null && positions[i] != null)
            {
                Instantiate(gameObjects[i], positions[i].position, positions[i].rotation);
            }
            else
            {
                Debug.LogWarning("Null");
            }
            
            
        }

        Debug.Log("Associated object to positions");
    }
}

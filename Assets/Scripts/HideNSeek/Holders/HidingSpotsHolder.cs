using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HidingSpotsHolder : MonoBehaviour
{
    [SerializeField]
    private Transform[] hidingSpots;

    public List<Transform> CurrentHidingSpots; 

    private DifficultyManager difficultyManager;

    public void Initialize()
    {

        difficultyManager = GameObject.FindGameObjectWithTag("Manager").GetComponent<DifficultyManager>();

        
        CurrentHidingSpots = GetRandomItems(hidingSpots, difficultyManager.NumberOfItemsToFind);

        Debug.Log("These are the current hiding spots:");
        foreach (var item in CurrentHidingSpots)
        {
            Debug.Log($"{item.name} at {item.transform.position}");
        }
    }

    public void ResetValues()
    {
        CurrentHidingSpots.Clear(); 
    }

    private List<Transform> GetRandomItems(Transform[] itemArray, int count)
    {
        List<Transform> items = new List<Transform>(itemArray); 
        List<Transform> selectedItems = new List<Transform>();

       
        for (int i = 0; i < items.Count; i++)
        {
            int randomIndex = Random.Range(i, items.Count);
            Transform temp = items[i];
            items[i] = items[randomIndex];
            items[randomIndex] = temp;
        }

    
        for (int i = 0; i < count && i < items.Count; i++) 
        {
            selectedItems.Add(items[i]);
        }

        return selectedItems;
    }


}

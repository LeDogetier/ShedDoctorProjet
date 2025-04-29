using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectHolder : MonoBehaviour
{
    [SerializeField]
    private GameObject[] toolsPrefabs;

    public List<GameObject> ToolsToFind;

    private DifficultyManager difficultyManager;

    public void Initialize()
    {

        difficultyManager = GameObject.FindGameObjectWithTag("Manager").GetComponent<DifficultyManager>();

        if (ToolsToFind.Count == 0)
        {
            ToolsToFind.AddRange(toolsPrefabs);
        }

        ToolsToFind = GetRandomItems(ToolsToFind, difficultyManager.NumberOfItemsToFind);

        Debug.Log("You must find the following items : ");
        foreach (var item in ToolsToFind)
        {
            Debug.Log(item.name);
        }
    }

    public void ResetValue()
    {
        ToolsToFind.Clear();
    }

    private List<GameObject> GetRandomItems(List<GameObject> itemList, int count)
    {
        
        List<GameObject> items = new List<GameObject>(itemList);
        List<GameObject> selectedItems = new List<GameObject>();

        
        for (int i = items.Count - 1; i > 0; i--)
        {
            int randomIndex = Random.Range(0, i + 1); 
            GameObject temp = items[i];
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

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlowManager : MonoBehaviour
{
    public ObjectHolder HolderObject;
    public HidingSpotsHolder HolderSpots;
    public AssignToolsToHidingSpot AssignTools;

    [SerializeField] private DifficultyManager difficultyManager;

    private bool isFlowManagerSetup = false;

    private void Update()
    {
        if (difficultyManager.isGameManagerSetup == true && isFlowManagerSetup == false)
        {
            GameObject[] holders = GameObject.FindGameObjectsWithTag("Holder");

            foreach (GameObject obj in holders)
            {
                if (HolderObject == null)
                {
                    HolderObject = obj.GetComponent<ObjectHolder>();
                }

                if (HolderSpots == null)
                {
                    HolderSpots = obj.GetComponent<HidingSpotsHolder>();
                }

                if (AssignTools == null)
                {
                    AssignTools = obj.GetComponent<AssignToolsToHidingSpot>();
                }

                if (HolderObject != null && HolderSpots != null && AssignTools != null)
                {
                    break;
                }
            }

            if (HolderObject != null && HolderSpots != null && AssignTools != null)
            {
                HolderObject.Initialize();
                HolderSpots.Initialize();
                AssignTools.Initialize();
                AssignTools.AssociateObjectToNewPosition(HolderObject.ToolsToFind, HolderSpots.CurrentHidingSpots);
            }
            else
            {
                Debug.LogWarning("A script is null");
            }

            isFlowManagerSetup = true;
        }
    }
  
}

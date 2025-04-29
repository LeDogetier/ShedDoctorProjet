using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ButtonDecorator : MonoBehaviour
{
    [SerializeField] private ActionManager actionManager;

    private void Awake()
    {
        actionManager = GameObject.FindGameObjectWithTag("Decorator").GetComponent<ActionManager>();
    }

    public void OnButtonClick()
    {
        if (actionManager != null)
        {
            actionManager.AddTabAction();
        }
        else
        {
            Debug.Log("action manager is null");
        }
        
    }
}

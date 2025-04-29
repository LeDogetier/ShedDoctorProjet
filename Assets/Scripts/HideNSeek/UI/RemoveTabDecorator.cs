using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RemoveTabDecorator : MonoBehaviour
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
            actionManager.RemoveTabAction();
        }
        else
        {
            Debug.Log("action manager is null");
        }

    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionManager : MonoBehaviour
{
    public static ActionManager Instance { get; private set; }

    private IPlayerAction _playerAction;

    public GameObject imageQ;
    public GameObject imageTab;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject); 
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject); 
    }

    private void Start()
    {
        _playerAction = new PlayerAction
        {
            Image = imageQ
        };
    }

    private void Update()
    {
        _playerAction.PerformAction();
    }

    public void AddTabAction()
    {
        _playerAction = new TabActionDecorator(_playerAction, imageTab);
        Debug.Log("Tools picture added!");
    }

    public void RemoveTabAction()
    {
        _playerAction = new PlayerAction { Image = imageQ };
        Debug.Log("Tools picture removed");
    }
}


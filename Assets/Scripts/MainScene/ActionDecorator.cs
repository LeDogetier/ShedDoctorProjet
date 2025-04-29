 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionDecorator : IPlayerAction
{
    private IPlayerAction _playerAction;

    public ActionDecorator(IPlayerAction playerAction)
    {
        _playerAction = playerAction;
    }

    public virtual void PerformAction()
    {
        _playerAction.PerformAction();
    }
}

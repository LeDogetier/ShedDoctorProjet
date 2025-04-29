using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TabActionDecorator : ActionDecorator
{
    private GameObject _imageTab;

    public TabActionDecorator(IPlayerAction playerAction, GameObject imageTab)
        : base(playerAction)
    {
        _imageTab = imageTab;
    }

    public override void PerformAction()
    {
        base.PerformAction();

        if (Input.GetKeyDown(KeyCode.Tab))
        {
            bool isActive = _imageTab.activeSelf;
            if (isActive)
                CanvasManager.Instance.HideImage(_imageTab);
            else
                CanvasManager.Instance.ShowImage(_imageTab);

            Debug.Log(isActive ? "Tab pressed: Hiding Image for Tab!" : "Tab pressed: Showing Image for Tab!");
        }
    }
}

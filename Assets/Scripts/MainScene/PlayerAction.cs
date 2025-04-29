using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAction : IPlayerAction
{
    public GameObject Image { get; set; }

    public void PerformAction()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            bool isActive = Image.activeSelf;
            if (isActive)
                CanvasManager.Instance.HideImage(Image);
            else
                CanvasManager.Instance.ShowImage(Image);

            Debug.Log(isActive ? "Q pressed: Hiding Image for Q!" : "Q pressed: Showing Image for Q!");
        }
    }
}

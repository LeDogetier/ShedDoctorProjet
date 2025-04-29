using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Player : MonoBehaviour
{
    public abstract void Update();
    public abstract void Start();
    public abstract void Controller();
    public abstract void MoveToLane();
    public abstract void Jump();
    public abstract System.Collections.IEnumerator Crouch();
}
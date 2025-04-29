using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerrainMovement : MonoBehaviour
{
    public float MoveSpeed = 10.0f;

    private void Update()
    {
        Move();
    }


    void Move()
    {
        transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z - MoveSpeed * Time.deltaTime);
    }

}

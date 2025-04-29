using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieMoveToTarget : MonoBehaviour
{
    [SerializeField]
    private Transform target;
    [SerializeField]
    private float speed = 5.0f;
    // Start is called before the first frame update
    private void Awake()
    {
        GameObject targetGameobject = GameObject.Find("WaitLine");
        if (targetGameobject != null)
        {
            target = targetGameobject.GetComponent<Transform>();
        }
        else
        {
            Debug.Log("targetGameobject is null");
        }

        if (target != null)
        {
            Debug.Log("Targer position found : " + target.position);
        }
        else
        {
            Debug.Log("target is null");
        }
    }

    // Update is called once per frame
    private void Update()
    {
        if (target != null)
        {
            transform.position = Vector3.MoveTowards(transform.position, target.position, speed * Time.deltaTime);

            if (Vector3.Distance(transform.position, target.position) < 0.1f)
            {
                transform.position = target.position;
            }
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//public class AsteroideMovement : MonoBehaviour
//{
//    [SerializeField] private float minMoveSpeed = 2f;    
//    [SerializeField] private float maxMoveSpeed = 5f;    
//    [SerializeField] private float startDelayRange = 7f;
//    [SerializeField] GameObject explosionPref;

//    private float moveSpeed;
//    private bool canMove = false; 

//    private void Start()
//    {
//        moveSpeed = Random.Range(minMoveSpeed, maxMoveSpeed);
//        float startDelay = Random.Range(0, startDelayRange);
//        Invoke(nameof(StartMovement), startDelay);
//    }

//    private void Update()
//    {
//        if (canMove)
//        {
//            Move();
//        }
//    }

//    private void Move()
//    {
//        transform.Translate(Vector2.down * moveSpeed * Time.deltaTime);
//    }

//    private void OnCollisionEnter(Collision collision)
//    {
//        if (collision.collider.CompareTag("Player"))
//        {
//            Instantiate(explosionPref, transform.position, Quaternion.identity);
//            Destroy(collision.gameObject);
//            Destroy(gameObject);
//            Debug.Log("game over");
//        }
//    }
//    private void StartMovement()
//    {
//        canMove = true;
//    }
//}
public class Asteroides : MonoBehaviour
{
    [SerializeField] private float minMoveSpeed = 2f;
    [SerializeField] private float maxMoveSpeed = 5f;
    [SerializeField] private float startDelayRange = 7f;
    [SerializeField] private GameObject explosionPref;

    private float moveSpeed;
    private bool canMove = false;

    private void Start()
    {
        moveSpeed = Random.Range(minMoveSpeed, maxMoveSpeed);
        float startDelay = Random.Range(0, startDelayRange);
        Invoke(nameof(StartMovement), startDelay);
    }

    private void Update()
    {
        if (canMove)
        {
            Move();
        }
    }

    private void Move()
    {
        transform.Translate(Vector2.down * moveSpeed * Time.deltaTime);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            Instantiate(explosionPref, transform.position, Quaternion.identity);
            Destroy(collision.gameObject);
            Destroy(gameObject);
            MiniGameManager.Instance.TriggerDefeat();
        }
        if(collision.collider.CompareTag("Mur"))
        {
            Destroy(gameObject);
            MiniGameManager.Instance.CheckGameEndCondition();
        }
    }

    private void StartMovement()
    {
        canMove = true;
    }
}

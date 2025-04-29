using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour 
{
    [SerializeField] private float moveSpeed = 30f;
    [SerializeField] private float maxDistance = 20f;
    private Vector3 _startPosition;
    public bool IsEnabled;
    private Rigidbody _rigidbody;

    [SerializeField] GameObject explosionPref;
    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    public void Activate(Vector3 startPosition)
    {
        gameObject.SetActive(true);
        _startPosition = startPosition;
        transform.position = _startPosition;
        _rigidbody.velocity = Vector3.zero; 
        IsEnabled = true;
    }

    public void Deactivate()
    {
        gameObject.SetActive(false);
        transform.position = _startPosition;
        _rigidbody.velocity = Vector3.zero;
        IsEnabled = false;
    }

    public void Launch(Vector3 startPosition)
    {
        Activate(startPosition);
        _rigidbody.AddForce(Vector2.up * moveSpeed, ForceMode.VelocityChange); 
    }

    private void Update()
    {
        CheckDistance();
    }

    private void CheckDistance()
    {
        if (Vector3.Distance(transform.position, _startPosition) >= maxDistance)
        {
            Deactivate();
        }
    }
    public Projectile Clone()
    {
        GameObject clone = Instantiate(this.gameObject);
        clone.SetActive(false);
        return clone.GetComponent<Projectile>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Asteroide"))
        {
            Debug.Log("ca touche");
            Instantiate(explosionPref, transform.position, Quaternion.identity);
            Destroy(other.gameObject);
            Destroy(gameObject);
            MiniGameManager.Instance.AsteroidDestroyed();
        }
    }
}
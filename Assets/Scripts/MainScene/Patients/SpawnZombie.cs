using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnZombie : MonoBehaviour
{
    [SerializeField]
    private GameObject zombiePrefab;
    [SerializeField]
    private Transform spawnPoint;
    // Start is called before the first frame update

    

    private void Awake()
    {
        GameObject zombieInstance = Instantiate(zombiePrefab, spawnPoint.position, spawnPoint.rotation);
        Debug.Log("Patient Spawned");
        
    }

}

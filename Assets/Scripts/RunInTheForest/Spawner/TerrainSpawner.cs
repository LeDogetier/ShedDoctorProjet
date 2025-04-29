using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class TerrainSpawner : MonoBehaviour
{
    public GameObject PineTreeNoLeaf;
    public GameObject PineLeaf;

    public float[] XTreePosition = {-4, 4};
    public float ZTreePosition = 15;

    public float SpawnInterval = 2f;
    public float DestroyInterval = 3f;
    void Start()
    {
        StartCoroutine(SpawnTreesAtInterval());
    }

    public void Spawn()
    {
        int treeType = Random.Range(1, 3);
        GameObject treeToSpawn = null;
        float xPosition = 0f;
        Quaternion objectRotation = Quaternion.identity;

        switch (treeType)
        {
            case 1:
                treeToSpawn = PineTreeNoLeaf;
                xPosition = ChooseRandomX(XTreePosition);
                break;
            case 2:
                treeToSpawn = PineLeaf;
                xPosition = ChooseRandomX(XTreePosition);
                break;
            default:
                break;
        }
        Vector3 spawnPosition = new Vector3(xPosition, 0, ZTreePosition);
        GameObject spawnedObject = Spawnable.SpawnObject(treeToSpawn, spawnPosition, objectRotation);
        StartCoroutine(ReturnToPoolAfterDelay(spawnedObject, DestroyInterval));
    }
    private IEnumerator SpawnTreesAtInterval()
    {
        while (true)
        {
            Spawn();
            yield return new WaitForSeconds(SpawnInterval);
        }
    }
    private IEnumerator ReturnToPoolAfterDelay(GameObject obj, float delay)
    {
        Debug.Log($"Starting coroutine for {obj.name}, returning to pool in {delay} seconds.");
        yield return new WaitForSeconds(delay);
        Debug.Log($"Attempting to return {obj.name} to pool.");
        Spawnable.ReturnObjectToPool(obj);
    }
    private float ChooseRandomX(float[] positions)
    {
        return positions[Random.Range(0, positions.Length)];
    }
}

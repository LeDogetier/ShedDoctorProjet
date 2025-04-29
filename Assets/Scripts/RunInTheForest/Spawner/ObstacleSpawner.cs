using System.Collections;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    public GameObject BigTreePrefab;
    public GameObject SmallTreePrefab;
    public GameObject RockPrefab;

    public float[] XSmallTreePositions = { 3.30f, 1.48f, -0.8f };
    public float[] XRockPositions = { 2f, 0f, -2f };
    public float XBigTreePosition = 0f;
    public float ZPosition = 15f;

    public float SpawnInterval = 2f;
    public float DestroyInterval = 1f;

    private void Start()
    {
        StartCoroutine(SpawnObstaclesAtInterval());
    }

    private IEnumerator SpawnObstaclesAtInterval()
    {
        while (true)
        {
            Spawn();
            yield return new WaitForSeconds(SpawnInterval);
        }
    }

    public void Spawn()
    {
        int obstacleType = Random.Range(1, 4);
        GameObject obstacleToSpawn = null;
        float xPosition = 0f;
        Quaternion objectRotation = Quaternion.identity;

        switch (obstacleType)
        {
            case 1:
                obstacleToSpawn = BigTreePrefab;
                xPosition = XBigTreePosition;
                objectRotation = Quaternion.Euler(0, 90, 0);
                break;

            case 2:
                obstacleToSpawn = SmallTreePrefab;
                xPosition = ChooseRandomX(XSmallTreePositions);
                objectRotation = Quaternion.Euler(0, 0, -7);
                break;

            case 3:
                obstacleToSpawn = RockPrefab;
                xPosition = ChooseRandomX(XRockPositions);
                objectRotation = Quaternion.Euler(0, 0, 0);
                break;

            default:
                return;
        }

        Vector3 spawnPosition = new Vector3(xPosition, 0, ZPosition);

        GameObject spawnedObject = Spawnable.SpawnObject(obstacleToSpawn, spawnPosition, objectRotation);

        StartCoroutine(ReturnToPoolAfterDelay(spawnedObject, DestroyInterval));
    }

    private float ChooseRandomX(float[] positions)
    {
        return positions[Random.Range(0, positions.Length)];
    }

    private IEnumerator ReturnToPoolAfterDelay(GameObject obj, float delay)
    {
        Debug.Log($"Starting coroutine for {obj.name}, returning to pool in {delay} seconds.");
        yield return new WaitForSeconds(delay);
        Debug.Log($"Attempting to return {obj.name} to pool.");
        Spawnable.ReturnObjectToPool(obj);
    }
}

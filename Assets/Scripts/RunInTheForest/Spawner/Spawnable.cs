using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Spawnable : MonoBehaviour
{
    public static List<PooledObjectInfo> ObjectPools = new List<PooledObjectInfo>(); 
    public static GameObject SpawnObject(GameObject objectToSpawn, Vector3 spawnPosition, Quaternion spawnRotation)
    {
        PooledObjectInfo pool = null;
        foreach (PooledObjectInfo info in ObjectPools)
        {
            if (info.LookUpString == objectToSpawn.name)
            {
                pool = info;
                break;
            }
        }
        if (pool == null)
        {
            pool = new PooledObjectInfo() {LookUpString = objectToSpawn.name};
            ObjectPools.Add(pool);
        }

        GameObject spawnableObj = null;
        foreach (GameObject obj in pool.InactiveObjects)
        {
            if (obj != null)
            {
                spawnableObj = obj;
                break;
            }
        }
        if (spawnableObj == null)
        {
            spawnableObj = Instantiate(objectToSpawn, spawnPosition, spawnRotation);
            spawnableObj.name = objectToSpawn.name;
        }
        else
        {
            spawnableObj.transform.position = spawnPosition;
            spawnableObj.transform.rotation = spawnRotation;
            pool.InactiveObjects.Remove(spawnableObj);
            spawnableObj.SetActive(true);
        }
        return spawnableObj;
    }
    public static void ReturnObjectToPool(GameObject obj)
    {
        PooledObjectInfo pool = ObjectPools.Find(info => info.LookUpString ==  obj.name);

        if (pool == null)
        {
            Debug.LogWarning($"No pool found for {obj.name}. Available pools: {string.Join(", ", ObjectPools.Select(p => p.LookUpString))}");
        }
        else
        {
            obj.SetActive(false);
            pool.InactiveObjects.Add(obj);
            Debug.Log($"Object {obj.name} successfully returned to pool.");
        }
    }
}

public class PooledObjectInfo
{
    public string LookUpString;
    public List<GameObject> InactiveObjects = new List<GameObject>();
}
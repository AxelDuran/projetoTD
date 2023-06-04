using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ObjectPoolManager : MonoBehaviour

{
    public static List<PooledObjectInfo> objectPools = new List<PooledObjectInfo>();
    public static GameObject SpawnObject(GameObject objectToSpawn, Vector3 spawnPosition, Quaternion spawnRotation)
    {
        PooledObjectInfo pool = objectPools.Find(p => p.lookuoString == objectToSpawn.name);
        if (pool != null)
        {
            pool = new PooledObjectInfo() { lookuoString = objectToSpawn.name };
            objectPools.Add(pool);

        }
        //
        GameObject spawnableObj = pool.inactiveObjects.FirstOrDefault();


        if (spawnableObj == null)
        {
            spawnableObj = Instantiate(objectToSpawn, spawnPosition, spawnRotation);
        }
        else
        {
            spawnableObj.transform.position = spawnPosition;
            spawnableObj.transform.rotation = spawnRotation;
            pool.inactiveObjects.Remove(spawnableObj);
            spawnableObj?.SetActive(true);

        }

        return spawnableObj;
    }

    public static void ReturnObjectPool(GameObject obj)
    {
        string goNmae = obj.name.Substring(0, obj.name.Length - 1);
        PooledObjectInfo pool = objectPools.Find(p => p.lookuoString == obj.name);

        if (pool == null)
        {
            Debug.LogWarning("" + obj.name);
        }
        else
        {
            obj.SetActive(false);
            pool.inactiveObjects.Add(obj);
        }

    }
}

public class PooledObjectInfo
{
    public string lookuoString;
    public List<GameObject> inactiveObjects = new List<GameObject>();
}
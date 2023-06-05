using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SpawnerEnemy : MonoBehaviour
{
   // [SerializeField] GameObject enemyToSpawn;
    [SerializeField] GameObject enemyToSpawn;
    [SerializeField] Transform localSpawn;
    [SerializeField] int maxEnemies = 5;
    [SerializeField] float spawnTime = 2f;
    [SerializeField] ObjectPoolManager _objectPoolManager;
    int objectCount = 0;
    float timeToSpawn = 0f;

    public int SetObjectCount( int valToSet)
    {
        return objectCount + valToSet;
    }

    public int ObjectCount()
    {
        return objectCount;
    }

    void Start()
    {
        _objectPoolManager = transform.GetComponent<ObjectPoolManager>();
    }

    void Update()
    {   
           SpawEnemies();
    }

    private void SpawEnemies()
    {
        if (Time.time >= timeToSpawn) 
        { 
            timeToSpawn = Time.time + spawnTime;
            if (objectCount < maxEnemies){
                enemyToSpawn = _objectPoolManager.GetPooledObjects();
                enemyToSpawn.transform.position = localSpawn.position;
                enemyToSpawn.transform.rotation = localSpawn.rotation;
                enemyToSpawn.SetActive(true);
                objectCount++;
            }

        }
    }
}

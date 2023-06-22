using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SpawnerEnemy : MonoBehaviour
{
    GameObject enemyToSpawn;
    [SerializeField] Transform localSpawn;
    [SerializeField] int maxEnemies = 5;
    [SerializeField] float spawnTime = 2f;
    [SerializeField] ObjectPoolManager _objectPoolManager;
    int objectCount;
    public float timeToSpawn = 0f;
    int enemyKilled = 0;

    public int GetEnemyKilled(int valToSet) //serve para guardar quantos inimigos morreram durante a onda atual
    {
        enemyKilled+= valToSet;
        return enemyKilled;
    }

    public int SetObjectCount( int valToSet) //serve para guardar quantos inimigos devem ser spawnados na onda atual
    {
        objectCount += valToSet;
        return objectCount;
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
        if (enemyKilled <= objectCount)
        {
            SpawEnemies();
        }
    }

    public void SpawEnemies()
    {
        if (Time.time >= timeToSpawn) 
        { 
            timeToSpawn = Time.time + spawnTime;
            if (objectCount < maxEnemies){
                int spawnChoice = (int)Mathf.Floor(Random.Range(0, 4f));
                print(spawnChoice);
                switch (spawnChoice)
                {
                    default:
                        enemyToSpawn = _objectPoolManager.GetPooledSoldier01();
                        enemyToSpawn.transform.position = localSpawn.position;
                        enemyToSpawn.transform.rotation = localSpawn.rotation;
                        enemyToSpawn.SetActive(true);
                        objectCount++;
                        break;
                    case 1:
                        enemyToSpawn = _objectPoolManager.GetPooledSoldier02();
                        enemyToSpawn.transform.position = localSpawn.position;
                        enemyToSpawn.transform.rotation = localSpawn.rotation;
                        enemyToSpawn.SetActive(true);
                        objectCount++;
                        break;
                    case 2:
                        enemyToSpawn = _objectPoolManager.GetPooledTank();
                        enemyToSpawn.transform.position = localSpawn.position;
                        enemyToSpawn.transform.rotation = localSpawn.rotation;
                        enemyToSpawn.SetActive(true);
                        objectCount++;
                        break;
                    case 3:
                        enemyToSpawn = _objectPoolManager.GetPooledZepelin();
                        enemyToSpawn.transform.position = localSpawn.position;
                        enemyToSpawn.transform.rotation = localSpawn.rotation;
                        enemyToSpawn.SetActive(true);
                        objectCount++;
                        break;
                }
            }

        }        
    }
}

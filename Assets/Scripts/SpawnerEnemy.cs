using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SpawnerEnemy : MonoBehaviour
{
    //classes importadas
    [SerializeField] GameManager _gameManager;

    GameObject enemyToSpawn;
    [SerializeField] Transform localSpawn;
    [SerializeField] int maxEnemies = 5;
    [SerializeField] float spawnTime = 2f;
    [SerializeField] ObjectPoolManager _objectPoolManager;
    public int type01, type02, type03, type04;
    int rangeValue;
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
            _gameManager.SetOnda(true);
            SpawEnemies();
        }
        else
        {
            _gameManager.SetOnda(false);
            RangeTypeMod();
        }
    }

    public void RangeTypeMod() //serve para aumentar as chances de spawn dos inimigos
    {
        int ondas = _gameManager.LeOnda();
        type01 += ondas;
        type02 += ondas;
        type03 += ondas;
        type04 += ondas;
    }

    public void SpawEnemies()
    {
        if (Time.time >= timeToSpawn) 
        { 
            timeToSpawn = Time.time + spawnTime;
            if (objectCount < maxEnemies){
                int rangeMod = type04;
                int spawnChoice = (int)Mathf.Floor(Random.Range(0, rangeMod));
                print(spawnChoice);
                if (spawnChoice <= type01)
                {
                    enemyToSpawn = _objectPoolManager.GetPooledSoldier01();
                    enemyToSpawn.transform.position = localSpawn.position;
                    enemyToSpawn.transform.rotation = localSpawn.rotation;
                    enemyToSpawn.SetActive(true);
                    objectCount++;
                }
                if (spawnChoice > type01 && spawnChoice <= type02)
                {
                    enemyToSpawn = _objectPoolManager.GetPooledSoldier02();
                    enemyToSpawn.transform.position = localSpawn.position;
                    enemyToSpawn.transform.rotation = localSpawn.rotation;
                    enemyToSpawn.SetActive(true);
                    objectCount++;
                }
                if(spawnChoice > type02 && spawnChoice <= type03)
                {
                    enemyToSpawn = _objectPoolManager.GetPooledTank();
                    enemyToSpawn.transform.position = localSpawn.position;
                    enemyToSpawn.transform.rotation = localSpawn.rotation;
                    enemyToSpawn.SetActive(true);
                    objectCount++;
                }
                if (spawnChoice > type03 && spawnChoice <= type04)
                {
                    enemyToSpawn = _objectPoolManager.GetPooledZepelin();
                    enemyToSpawn.transform.position = localSpawn.position;
                    enemyToSpawn.transform.rotation = localSpawn.rotation;
                    enemyToSpawn.SetActive(true);
                    objectCount++;
                }
            }

        }        
    }
}

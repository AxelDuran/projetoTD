using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerEnemy : MonoBehaviour
{
   // [SerializeField] GameObject enemyToSpawn;
    [SerializeField] GameObject[] enemyToSpawn;
    [SerializeField] int maxEnemies = 5;
    int objectCount = 0;

    void Start()
    {

    }

    void Update()
    {       
        SpawEnemies();
    }

    private void SpawEnemies(){
        for (int i = 0; i < enemyToSpawn.Length; i++)
        {
          if (objectCount < maxEnemies){

                 Instantiate(enemyToSpawn[i], transform.position, transform.rotation);
            
                objectCount++;
          }
       }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerEnemy : MonoBehaviour
{
   // [SerializeField] GameObject enemyToSpawn;
    [SerializeField] GameObject[] enemyToSpawn;
    [SerializeField] Transform[] localSpawn;
    [SerializeField] int maxEnemies = 5;
    [SerializeField] float spawnTime = 2f;
    int objectCount = 0;
    float timeToSpawn = 0f;

    void Start()
    {

    }

    void Update()
    {   
       
           SpawEnemies();
    }

    private void SpawEnemies()
    {
        if (Time.time >= timeToSpawn) 
        { 
           // Spawna inimigos da lista de forma aleatoria
            int randomSpawn = Random.Range(0,enemyToSpawn.Length);

            // Define tempo de espera para spawnar um novo inimigo
            timeToSpawn = Time.time + spawnTime;
            if (objectCount < maxEnemies){
                for (int i = 0;i < localSpawn.Length;i++)
                {
                 Instantiate(enemyToSpawn[randomSpawn], localSpawn[i].position, localSpawn[i].rotation);

                 objectCount++;             
                }
            
                }
       
        }
    }
}

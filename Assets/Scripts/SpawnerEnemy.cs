using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerEnemy : MonoBehaviour
{
    [SerializeField] GameObject enemyToSpawn;


    void Start()
    {

    }

    void Update()
    {
        for (var i = 0; i < 10; i++)
        {
            Instantiate(enemyToSpawn, transform.position, transform.rotation);
        }
        
    }
}

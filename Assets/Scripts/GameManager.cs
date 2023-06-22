using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] int recursos;
    [SerializeField] int ondas;
    [SerializeField] int ondaAtual;
    [SerializeField] SpawnerEnemy _SpawnEnemy;

    public int LeRecurso(){
        return recursos;
    }



    void Start()
    {
        ondaAtual = 1;
    }

    void Update()
    {
        int enemiesInPlay = _SpawnEnemy.GetEnemyKilled(0);
    }
}

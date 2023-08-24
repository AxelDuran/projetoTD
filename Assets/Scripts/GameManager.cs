using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] int recursos;
    [SerializeField] int ondas;
    [SerializeField] int ondaAtual;
    [SerializeField] SpawnerEnemy _SpawnEnemy;
    [SerializeField] bool ondaAtivada;
    int enemyKilled = 0;

    public int LeRecurso() //serve para ler o valor da variavel recurso
    {
        return recursos;
    }

    public int LeOnda() //serve para ler quantas ondas ja se passaram
    {
        return ondas;
    } 

    public bool SetOnda(bool valor) //serve para verificar se tem alguma onda ativada
    {
        ondaAtivada = valor;
        return ondaAtivada;
    }

    void Start()
    {
        ondaAtivada = true;
        ondaAtual = 1;
    }

    void Update()
    {
        int maxEnemys = _SpawnEnemy.GetMaxEnemy();
        int enemyCount = _SpawnEnemy.ObjectCount();
        /*
        enemiesKilled = _SpawnEnemy.GetEnemyKilled();
        int enemiesSpawned = _SpawnEnemy.ObjectCount();
        if (!ondaAtivada && enemiesKilled<=enemiesSpawned)
        {
            ondaAtual += 1;
        }*/
        if (ondaAtivada && enemyCount < maxEnemys)
        {
            _SpawnEnemy.SpawEnemies();
        }

        if (enemyKilled == maxEnemys && ondaAtivada) //realiza ações ao final da onda
        {
            ondaAtivada = false;
            enemyKilled = 0;
            Invoke(nameof(ResetaOnda), 2);
        }
    }

    public void ResetaOnda()
    {
        _SpawnEnemy.SetMaxEnemy(1);
        _SpawnEnemy.ResetaSpawner();
        ondaAtivada=true;
    }

    public int SetEnemyKilled(int valToSet) //serve para guardar quantos inimigos morreram durante a onda atual
    {
        enemyKilled += valToSet;
        return enemyKilled;
    }
    public int GetEnemyKilled() //serve para pegar quantos inimigos foram de base
    {
        return enemyKilled;
    }
}

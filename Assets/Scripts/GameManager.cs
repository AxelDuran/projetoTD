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
        ondaAtual = 1;
    }

    void Update()
    {
        int enemiesKilled = _SpawnEnemy.GetEnemyKilled(0);
        int enemiesSpawned = _SpawnEnemy.ObjectCount();
        if (!ondaAtivada && enemiesKilled<=enemiesSpawned)
        {
            ondaAtual += 1;
            enemiesKilled = 0;
        }
    }
}

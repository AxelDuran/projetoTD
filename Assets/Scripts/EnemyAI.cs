using Pathfinding;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EnemyAI : MonoBehaviour
{
    AIDestinationSetter destination;
    public Transform target;
    public string tagName;
    [SerializeField] GameObject _SpawnEnemyGO;
    SpawnerEnemy _SpawnEnemy;
    // float enemySpeed;

    //[SerializeField] Vector3 targetPlace;
    // GameObject m_Enemy;
    // NavMeshAgent m_Agent;
    void Start()
    {
        _SpawnEnemyGO = GameObject.Find("/Managers/SpawmManager");
        _SpawnEnemy = _SpawnEnemyGO.GetComponent<SpawnerEnemy>();
        destination = GetComponent<AIDestinationSetter>();
        target = GameObject.FindGameObjectWithTag(tagName).transform;
        destination.target = target;
        //m_Enemy = gameObject;
        //m_Agent = m_Enemy.GetComponent<NavMeshAgent>();
        
    }

    void Update()
    {
        destination.target = target;
        //m_Agent.SetDestination(targetPlace);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == tagName) {
            Debug.Log(other.name);
            //ObjectPoolManager.ReturnObjectPool(gameObject);
            _SpawnEnemy.GetEnemyKilled(1);
            gameObject.SetActive(false);
        }
    }
}

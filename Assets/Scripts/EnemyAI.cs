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
    GameManager _gameManager;
    // float enemySpeed;

    [SerializeField] int vidaInimigo;
    int vidaOutimigo;

    //[SerializeField] Vector3 targetPlace;
    // GameObject m_Enemy;
    // NavMeshAgent m_Agent;
    void Start()
    {
        vidaOutimigo = vidaInimigo;
        _SpawnEnemyGO = GameObject.Find("/Managers/GameManager");
        _gameManager = _SpawnEnemyGO.GetComponent<GameManager>();
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
        if(vidaOutimigo <= 0)
        {
            _gameManager.SetEnemyKilled(1);
            gameObject.SetActive(false);
        }
    }
    
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == tagName) {
            _gameManager.SetEnemyKilled(1);
            gameObject.SetActive(false);
        }
    }

    public int GetVidaInimigo()
    {
        return vidaOutimigo;
    }
    public void SetVidaInimigo(int dano)
    {
        vidaOutimigo -= dano;
    }

}

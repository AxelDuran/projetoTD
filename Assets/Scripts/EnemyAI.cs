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
    // float enemySpeed;

    //[SerializeField] Vector3 targetPlace;
    // GameObject m_Enemy;
    // NavMeshAgent m_Agent;
    void Start()
    {
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
        if (other.tag == "HQ" ) {
            Debug.Log(other.name);
           //ObjectPoolManager.ReturnObjectPool(gameObject);
           gameObject.SetActive(false);
        }
    }
}

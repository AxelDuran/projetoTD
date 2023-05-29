using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    float enemySpeed;

   [SerializeField] Vector3 targetPlace;
    GameObject m_Enemy;
    NavMeshAgent m_Agent;
    void Start()
    {
        m_Enemy = gameObject;
        m_Agent = m_Enemy.GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        m_Agent.SetDestination(targetPlace);
    }
}

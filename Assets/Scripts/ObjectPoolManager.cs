using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ObjectPoolManager : MonoBehaviour
{
    public static ObjectPoolManager _objectPoolManagerIns;

    //pooled objects para usar em spawns depois
    public List<GameObject> _pooledSoldier01;
    public List<GameObject> _pooledSoldier02;
    public List<GameObject> _pooledTank;

    public List<GameObject> _objectsToPool;
    public int _poolCountS01;
    public int _poolCountS02;
    public int _poolCountT;

    void Awake()
    {
        _objectPoolManagerIns = this;
    }

    void Start()
    {
        _pooledSoldier01 = new List<GameObject>();
        _pooledSoldier02 = new List<GameObject>();
        _pooledTank = new List<GameObject>();
        GameObject tmp;
        //cria o pool de soldados 01
        for(int i = 0; i < _poolCountS01; i++)
        {
            tmp = Instantiate(_objectsToPool[0]);
            tmp.SetActive(false);
            _pooledSoldier01.Add(tmp);
        }
        //cria o pool de soldados 02
        for (int i = 0; i < _poolCountS02; i++)
        {
            tmp = Instantiate(_objectsToPool[1]);
            tmp.SetActive(false);
            _pooledSoldier02.Add(tmp);
        }
        //cria o pool de tanques
        for (int i = 0; i < _poolCountT; i++)
        {
            tmp = Instantiate(_objectsToPool[2]);
            tmp.SetActive(false);
            _pooledTank.Add(tmp);
        }
    }

    public GameObject GetPooledSoldier01()
    {
        for(int i = 0; i < _poolCountS01; i++)
        {
            if (!_pooledSoldier01[i].activeInHierarchy)
            {
                return _pooledSoldier01[i];
            }
        }
        return null;
    }

    public GameObject GetPooledSoldier02()
    {
        for(int i = 0; i < _poolCountS02; i++)
        {
            if (!_pooledSoldier02[i].activeInHierarchy)
            {
                return _pooledSoldier02[i];
            }
        }
        return null;
    }

    public GameObject GetPooledTank()
    {
        for(int i = 0; i < _poolCountT; i++)
        {
            if (!_pooledTank[i].activeInHierarchy)
            {
                return _pooledTank[i];
            }
        }
        return null;
    }
}


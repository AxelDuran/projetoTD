using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ObjectPoolManager : MonoBehaviour
{
    public static ObjectPoolManager _objectPoolManagerIns;
    public List<GameObject> _pooledObjects;
    public GameObject _objectsToPool;
    public int _poolCount;

    void Awake()
    {
        _objectPoolManagerIns = this;
    }

    void Start()
    {
        _pooledObjects = new List<GameObject>();
        GameObject tmp;
        for(int i = 0; i < _poolCount; i++)
        {
            tmp = Instantiate(_objectsToPool);
            tmp.SetActive(false);
            _pooledObjects.Add(tmp);
        }
    }

    public GameObject GetPooledObjects()
    {
        for(int i = 0; i < _poolCount; i++)
        {
            if (!_pooledObjects[i].activeInHierarchy)
            {
                return _pooledObjects[i];
            }
        }
        return null;
    }
}


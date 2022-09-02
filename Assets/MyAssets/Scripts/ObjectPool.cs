using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : Singleton<ObjectPool>
{

    [Serializable]
    public struct Pool
    {
        public PoolItems items;
        public GameObject prefab;
        public int poolSize;
    }

    [SerializeField] Pool[] pools;

    private readonly Dictionary<PoolItems, Queue<GameObject>> pooledObjects =
            new Dictionary<PoolItems, Queue<GameObject>>();

    private readonly Dictionary<PoolItems, Pool> pooledObjectsContainer =
            new Dictionary<PoolItems, Pool>();


    private void OnEnable()
    {
        foreach (Pool pool in pools)
        {
            pooledObjects.Add(pool.items, new Queue<GameObject>());
            pooledObjectsContainer.Add(pool.items, pool);
            Spawn(pool.items);
        }
    }

    public void Spawn(PoolItems items)
    {
        pooledObjects[items].Clear();

        for (int i = 0; i < pooledObjectsContainer[items].poolSize; i++)
        {
            GameObject obj = Instantiate(pooledObjectsContainer[items].prefab);
            obj.SetActive(false);
            pooledObjects[items].Enqueue(obj);
        }
    }


    public GameObject GetFromPool(PoolItems items)
    {
        if (pooledObjects[items].Count > 0)
        {
            GameObject obj = pooledObjects[items].Dequeue();
            obj.SetActive(true);
            return obj;
        }
        else
        {
            GameObject obj = Instantiate(pooledObjectsContainer[items].prefab);
            return obj;
        }
    }

    public void ReturnToPool(GameObject poolObject, PoolItems item, float time)
    {
        StartCoroutine(ReturnTime(poolObject, item, time));
    }

    IEnumerator ReturnTime(GameObject poolObject, PoolItems item, float time)
    {
        yield return new WaitForSeconds(time);
        pooledObjects[item].Enqueue(poolObject);
        poolObject.SetActive(false);
    }
}

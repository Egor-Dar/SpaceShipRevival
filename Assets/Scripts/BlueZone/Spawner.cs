using System;
using System.Collections.Generic;
using System.Linq;
using Base;
using CorePlugin.Cross.Events.Interface;
using OrangeZone;
using UnityEngine;
using UnityEngine.Pool;
using Random = UnityEngine.Random;

namespace BlueZone
{
    public abstract class Spawner<T> : MonoBehaviour where T : MonoBehaviour, IPoolObject
    {
        [SerializeField] private protected T[] prefabs;
        [SerializeField] private protected int defaultCapacity = 10;
        [SerializeField] private protected int maxSize = 100;

        private protected ObjectPool<IPoolObject> ObjectPool;
        private protected Dictionary<Type, IPoolObject[]> PoolObjects;

        private protected virtual void Start()
        {
            PoolObjects = new Dictionary<Type, IPoolObject[]>
            {
                {typeof(Bullet), prefabs.Cast<IPoolObject>().ToArray()},
            };

            ObjectPool = new ObjectPool<IPoolObject>(CreateFunc, ActionOnGet, ActionOnRelease, ActionOnDestroy,
                true, defaultCapacity, maxSize);
        }

        private protected virtual void ActionOnDestroy(IPoolObject obstacle)
        {
            obstacle.Destroy();
        }

        private protected virtual void ActionOnRelease(IPoolObject obstacle)
        {
            obstacle.SetActive(false);
        }

        private protected virtual IPoolObject CreateFunc()
        {
            var keys = PoolObjects.Keys.ToArray();
            var randomKey = keys[Random.Range(0, keys.Length)];
            var value = PoolObjects[randomKey];
            return value[Random.Range(0, value.Length)].Instantiate();
        }

        private protected abstract Vector3 GetSpawnPosition();

        private protected virtual void ActionOnGet(IPoolObject obstacle)
        {
            obstacle.SetActive(true);
            obstacle.SetPosition(GetSpawnPosition());
            obstacle.ResetState();
        }

        private protected virtual void OnDestroy()
        {
            ObjectPool.Clear();
        }

        private protected virtual void OnRelease(IPoolObject poolObject)
        { 
            ObjectPool?.Release(poolObject);
        }
    }
}
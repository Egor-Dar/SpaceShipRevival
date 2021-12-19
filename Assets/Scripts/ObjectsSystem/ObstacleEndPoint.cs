using System;
using Base;
using CorePlugin.Cross.Events.Interface;
using CorePlugin.Extensions;
using ObjectsSystem.ObjectBase.Interfaces;
using UnityEngine;

namespace ObjectsSystem
{
    [RequireComponent(typeof(Collider2D))]
    public class ObstacleEndPoint : MonoBehaviour, IEventHandler
    {
        private event PoolDelegates.ReleasePoolObjectObstacles ObstaclePool;

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.TryGetComponent<IPoolObject>(out var poolObject))
            {
                ObstaclePool!.Invoke(poolObject);
            }
        }

        public void InvokeEvents()
        {
            
        }

        public void Subscribe(params Delegate[] subscribers)
        {
            EventExtensions.Subscribe(ref ObstaclePool, subscribers);
        }

        public void Unsubscribe(params Delegate[] unsubscribers)
        {
            EventExtensions.Unsubscribe(ref ObstaclePool, unsubscribers);
        }
    }
}
using System;
using Base;
using CorePlugin.Cross.Events.Interface;
using CorePlugin.Extensions;
using UnityEngine;

namespace OrangeZone
{
    [RequireComponent(typeof(Collider2D))]
    public class BulletEndPoint : MonoBehaviour, IEventHandler
    {
        private event PoolDelegates.ReleasePoolObjectBullets BulletsPool;

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.TryGetComponent<IPoolObject>(out var poolObject))
            {
                if (!(poolObject is Bullet)) return;
                BulletsPool!.Invoke(poolObject);
            }
        }

        public void InvokeEvents()
        {
        }

        public void Subscribe(params Delegate[] subscribers)
        {
            EventExtensions.Subscribe(ref BulletsPool, subscribers);
        }

        public void Unsubscribe(params Delegate[] unsubscribers)
        {
            EventExtensions.Unsubscribe(ref BulletsPool, unsubscribers);
        }
    }
}
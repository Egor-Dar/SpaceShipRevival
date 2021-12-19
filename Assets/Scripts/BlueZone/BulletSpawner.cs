using System;
using System.Collections.Generic;
using System.Linq;
using Base;
using CorePlugin.Attributes.EditorAddons;
using CorePlugin.Cross.Events.Interface;
using CorePlugin.Extensions;
using ObjectsSystem;
using UnityEngine;

namespace BlueZone
{
    [CoreManagerElement]
    public class BulletSpawner : Spawner<Bullet>, IEventSubscriber, IEventHandler
    {
        private event PlayerEvents.GetCurrentPlayerPosition playerPos;

        private protected override Vector3 GetSpawnPosition()
        {
            return playerPos!.Invoke();
        }

        private void Spawn()
        {
            var newBullet = ObjectPool.Get();
            newBullet.Initialize(OnRelease);
        }

        public void InvokeEvents()
        {
        }

        public void Subscribe(params Delegate[] subscribers)
        {
            EventExtensions.Subscribe(ref playerPos, subscribers);
        }

        public void Unsubscribe(params Delegate[] unsubscribers)
        {
            EventExtensions.Unsubscribe(ref playerPos, unsubscribers);
        }

        public Delegate[] GetSubscribers()
        {
            return new Delegate[]
            {
                (PoolDelegates.ReleasePoolObjectBullets) OnRelease,
                (PlayerEvents.SpawnBullets) Spawn
            };
        }
    }
}
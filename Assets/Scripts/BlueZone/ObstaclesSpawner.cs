using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Base;
using CorePlugin.Attributes.EditorAddons;
using CorePlugin.Cross.Events.Interface;
using ObjectsSystem;
using UnityEngine;
using UnityEngine.Pool;
using Random = UnityEngine.Random;

namespace BlueZone
{
    [CoreManagerElement]
    public class ObstaclesSpawner : Spawner<Obstacle>, IEventSubscriber
    {
        private Vector2 screenBounds;

        private protected override void Start()
        {
            base.Start();

            StartCoroutine(Spawn());
        }

        private void ReceiveScreenBounds(Vector2 newScreenBounds)
        {
            screenBounds = newScreenBounds;
        }

        private protected override Vector3 GetSpawnPosition()
        {
            return new Vector3(screenBounds.x + 5f, Random.Range(-screenBounds.y, screenBounds.y), 0);
        }

        private IEnumerator Spawn()
        {
            while (true)
            {
                yield return new WaitForSeconds(Random.Range(0.5f, 1f));
                var newObstacle = ObjectPool.Get();
                newObstacle.Initialize(OnRelease);
            }
        }

        public Delegate[] GetSubscribers()
        {
            return new Delegate[]
            {
                (PoolDelegates.ReleasePoolObjectObstacles) OnRelease,
                (GeneralEvents.GetScreenBound) ReceiveScreenBounds
            };
        }
    }
}
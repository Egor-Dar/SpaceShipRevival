using System;
using BlueZone;
using ObjectsSystem.ObjectBase;
using ObjectsSystem.ObjectBase.Interfaces;
using UnityEngine;

namespace ObjectsSystem
{

    public class Bullet : Flyable
    {

        public override void Initialize(Action<IPoolObject> onRelease)
        {
            transform.localScale = size;
            spriteRenderer.sortingOrder = order;
            onReleaseNeeded = onRelease;
        }

        public override void FixedUpdate()
        {
            var position = transform.position + Vector3.right * speed * Time.fixedDeltaTime;
            rigidBody.MovePosition(position);
        }

        public override void OnTriggerEnter2D(Collider2D other)
        {
            if (markedForDie) return;
            if (other.TryGetComponent<IDamageable>(out var obstacle))
            {
                if (obstacle is SpaceShipAction) return;
                markedForDie = true;
                obstacle.ReceiveDamage(damage);
                Die();
            }
        }

        private protected override void Die()
        {
            onReleaseNeeded.Invoke(this);
            rigidBody.velocity = Vector2.zero;
            ResetState();
        }

    }
}
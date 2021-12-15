using System;
using System.Collections;
using System.Linq;
using Animate;
using CorePlugin.Attributes.EditorAddons;
using UnityEngine;

namespace OrangeZone
{ 
    public class Obstacle : Flyable, IDamageable
    {
        public override void FixedUpdate()
        {
            var position = transform.position + Vector3.left * speed * Time.fixedDeltaTime;
            rigidBody.MovePosition(position);
        }
        public override void OnTriggerEnter2D(Collider2D other)
        {
            if (markedForDie) return;
            if (other.TryGetComponent<IDamageable>(out var damageable))
            {
                if (damageable is Obstacle) return;
                onReleaseNeeded.Invoke(this);
                damageable.ReceiveDamage(damage);
            }
        }
        public void ReceiveDamage(int damage)
        {
            if (markedForDie) return;
            currentHeath -= damage;
            if (currentHeath <= 0)
            {
                markedForDie = true;
                Die();
            }
        }


        public override void Initialize(Action<IPoolObject> onRelease)
        {
            currentHeath = life;
            spriteRenderer.sortingOrder = order;
            onReleaseNeeded = onRelease;
            _animatable = new ObstacleAnimation().Initialize(explosionAnimator);
        }
    }
}
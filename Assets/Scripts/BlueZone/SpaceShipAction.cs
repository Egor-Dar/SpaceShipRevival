using System;
using System.Collections;
using Animate;
using Animate.Interfaces;
using Base;
using CorePlugin.Attributes.EditorAddons;
using CorePlugin.Core;
using CorePlugin.Cross.Events.Interface;
using CorePlugin.Extensions;
using ObjectsSystem.ObjectBase.Interfaces;
using UnityEngine;

namespace BlueZone
{
    [CoreManagerElement]
    public class SpaceShipAction : MonoBehaviour, IEventSubscriber, IDamageable, IEventHandler
    {
        [SerializeField] private SpriteRenderer spriteRenderer;
        [SerializeField] private Animator animator;
        [SerializeField] private int currentMaxHealth;
        private bool markedForDie;
        private int currentHealth;
        private Vector2 screenBounds;
        private float objectWidth;
        private float objectHeight;

        private IAnimatable<Vector2> _animatable;

        private static int DieAnimation = Animator.StringToHash("DieAnimation");
        private const int MaxHealth = 30;
        private event PlayerEvents.SpawnBullets SpawnBullets;
        private event PlayerEvents.OnPlayerHealthRemove OnPlayerHealthRemove;
        private event PlayerEvents.OnPlayerHealthAdd OnPlayerHealthAdd;
        private event PlayerEvents.OnPlayerHealthChanged OnPlayerHealthChanged;
        private event ScreenStateDelegates.Play Play;
        private event ScreenStateDelegates.Die Die;

        private Vector2 GetCurrentPlayerPosition()
        {
            return transform.position;
        }

        private int SetCurrentMaxHealth
        {
            set => currentMaxHealth = Mathf.Clamp(value, 0, MaxHealth);
            get => currentMaxHealth;
        }

        private int SetCurrentHealth
        {
            set => currentHealth = Mathf.Clamp(value, 0, currentMaxHealth);
            get => currentHealth;
        }

        private void AddMaxHealth(int value)
        {
            SetCurrentMaxHealth += value;
        }

        private void Start()
        {
            markedForDie = false;
            transform.position = new Vector3(-screenBounds.x - spriteRenderer.sprite.bounds.size.x, 0, 0);
            var bounds = spriteRenderer.bounds;
            objectWidth = bounds.extents.x; //extents = size of width / 2
            objectHeight = bounds.extents.y; //extents = size of height / 2
            _animatable = new PlayerAnimation().Initialize(animator);
        }

        private void ReceiveScreenBounds(Vector2 newScreenBounds)
        {
            screenBounds = newScreenBounds;
        }

        private void Run(Vector2 dir)
        {
            _animatable.Run(dir);
            transform.Translate(dir * 5f * Time.deltaTime);

            Vector2 viewPos = transform.position;
            viewPos.x = Mathf.Clamp(viewPos.x, screenBounds.x * -1 + objectWidth, screenBounds.x - objectWidth);
            viewPos.y = Mathf.Clamp(viewPos.y, screenBounds.y * -1 + objectHeight, screenBounds.y - objectHeight);
            transform.position = viewPos;
        }

        private void Attack()
        {
            SpawnBullets!.Invoke();
        }

        public Delegate[] GetSubscribers()
        {
            return new Delegate[]
            {
                (PlayerEvents.RunVert) Run,
                (PlayerEvents.Shoot) Attack,
                (PlayerEvents.GetCurrentPlayerPosition) GetCurrentPlayerPosition,
                (GeneralEvents.GetScreenBound) ReceiveScreenBounds
            };
        }

        private void OnDestroy()
        {
            EventInitializer.Unsubscribe(this);
        }

        private IEnumerator DieTime()
        {
            if (animator.HasState(0, DieAnimation))
            {
                animator.Play(DieAnimation);
                yield return new WaitUntil(() => animator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1f);
            }

            Die?.Invoke();
            Destroy(gameObject);
        }

        public void ReceiveDamage(int damage)
        {
            if (markedForDie) return;
            currentHealth -= damage;
            OnPlayerHealthRemove!.Invoke(currentHealth, currentMaxHealth);
            if (currentHealth <= 0)
            {
                markedForDie = true;
                StartCoroutine(DieTime());
            }
        }

        public void InvokeEvents()
        {
            currentHealth = currentMaxHealth;
            OnPlayerHealthChanged!.Invoke(currentMaxHealth, MaxHealth);
        }

        public void Subscribe(params Delegate[] subscribers)
        {
            EventExtensions.Subscribe(ref SpawnBullets, subscribers);
            EventExtensions.Subscribe(ref OnPlayerHealthChanged, subscribers);
            EventExtensions.Subscribe(ref OnPlayerHealthRemove, subscribers);
            EventExtensions.Subscribe(ref OnPlayerHealthAdd, subscribers);
            EventExtensions.Subscribe(ref Play, subscribers);
            EventExtensions.Subscribe(ref Die, subscribers);
        }

        public void Unsubscribe(params Delegate[] unsubscribers)
        {
            EventExtensions.Unsubscribe(ref SpawnBullets, unsubscribers);
            EventExtensions.Unsubscribe(ref OnPlayerHealthChanged, unsubscribers);
            EventExtensions.Unsubscribe(ref OnPlayerHealthRemove, unsubscribers);
            EventExtensions.Unsubscribe(ref OnPlayerHealthAdd, unsubscribers);
            EventExtensions.Unsubscribe(ref Play, unsubscribers);
            EventExtensions.Unsubscribe(ref Die, unsubscribers);
        }
    }
}
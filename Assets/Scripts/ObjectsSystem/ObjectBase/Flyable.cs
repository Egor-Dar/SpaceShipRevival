using System;
using Animate.Interfaces;
using CorePlugin.Attributes.EditorAddons;
using CorePlugin.Attributes.Headers;
using CorePlugin.Attributes.Validation;
using ObjectsSystem.ObjectBase.Interfaces;
using UnityEngine;

namespace ObjectsSystem.ObjectBase
{
    [CoreManagerElement, RequireComponent(typeof(Rigidbody2D), typeof(SpriteRenderer), typeof(Collider2D)),
     RequireComponent(typeof(Animator))]
    public abstract class Flyable : MonoBehaviour, IPoolObject
    {
        [ReferencesHeader] [NotNull] [SerializeField] private protected SpriteRenderer spriteRenderer;
        [PrefabHeader] [PrefabRequired] [SerializeField] private protected Animator explosionAnimator;

        [NotNull] [SerializeField] private protected Animator animator;
        [NotNull] [SerializeField] private protected Rigidbody2D rigidBody;
        [SettingsHeader] [SerializeField] private protected int damage;


        [SerializeField] private protected int life;
        [SerializeField] private protected Vector3 size;
        [SerializeField] private protected int order;
        [SerializeField] private protected float speed;
        [SerializeField] private protected float currentSpeed;


        private protected bool markedForDie;
        private protected IAnimatable<Transform> _animatable;

        private protected Action<IPoolObject> onReleaseNeeded;

        public bool IsReleased { get; private set; }

        private protected int currentHeath;

        public abstract void FixedUpdate();
        public abstract void OnTriggerEnter2D(Collider2D other);


        public virtual void Destroy()
        {
            Destroy(this);
        }

        public abstract void Initialize(Action<IPoolObject> onRelease);


        public virtual IPoolObject Instantiate()
        {
            return Instantiate(this);
        }

        public virtual void SetPosition(Vector3 newPos)
        {
            transform.position = newPos;
        }

        public void OnGet()
        {
            IsReleased = false;
        }
        
        public void OnRelease()
        {
            IsReleased = true;
        }

        private protected virtual void Reset()
        {
            rigidBody = GetComponent<Rigidbody2D>();
            rigidBody.gravityScale = 0;
            spriteRenderer = GetComponent<SpriteRenderer>();
        }

        private protected virtual void Die()
        {
            _animatable.Run(transform);
            onReleaseNeeded.Invoke(this);
        }
        public virtual void SetActive(bool state)
        {
            gameObject.SetActive(state);
        }

        public virtual void ResetState()
        {
            markedForDie = false;
        }
    }
}

using System;
using CorePlugin.Attributes.Headers;
using CorePlugin.Attributes.Validation;
using UnityEngine;

namespace OrangeZone
{
    [RequireComponent(typeof(Rigidbody2D), typeof(SpriteRenderer), typeof(CircleCollider2D))]
    public class Star : MonoBehaviour, IPoolObject
    {
        [ReferencesHeader] 
        [NotNull] [SerializeField] private Rigidbody2D rigidbody2D;

        [NotNull] [SerializeField] private SpriteRenderer spriteRenderer;
        [NotNull] [SerializeField] private CircleCollider2D circle;

        [SettingsHeader] [SerializeField] private Vector3 size = new Vector3(1f, 1f, 1f);
        [SerializeField] private int order = 1;
        [SerializeField] private float speed;

        private Action<IPoolObject> onReleaseNeeded;

        public void SetActive(bool state)
        {
            gameObject.SetActive(state);
        }

        private void Reset()
        {
            rigidbody2D = GetComponent<Rigidbody2D>();
            spriteRenderer = GetComponent<SpriteRenderer>();
            circle = GetComponent<CircleCollider2D>();
        }

        public IPoolObject Instantiate()
        {
            return Instantiate(this);
        }

        public void SetPosition(Vector3 newPos)
        {
            transform.position = newPos;
        }

        private void Update()
        {
            var position = transform.position + Vector3.left * speed * Time.deltaTime;
            rigidbody2D.MovePosition(position);
        }

        public void ResetState()
        {
            transform.position = Vector3.zero;
        }

        public void Destroy()
        {
            Destroy(gameObject);
        }

        public void Initialize(Action<IPoolObject> onRelease)
        {
            transform.localScale = size;
            circle.radius = spriteRenderer.bounds.extents.y;
            spriteRenderer.sortingOrder = order;
            onReleaseNeeded = onRelease;
        }
    }
}
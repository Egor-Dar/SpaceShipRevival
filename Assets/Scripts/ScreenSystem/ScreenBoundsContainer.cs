using System;
using Base;
using CorePlugin.Cross.Events.Interface;
using CorePlugin.Extensions;
using UnityEngine;

namespace ScreenSystem
{
    [RequireComponent(typeof(Camera))]
    public class ScreenBoundsContainer : MonoBehaviour, IEventHandler
    {
        [SerializeField] private Camera mainCamera;

        private event GeneralEvents.GetScreenBound GetScreenBounds;
        private event GeneralEvents.GetScreenSize GetScreenSize;

        private Vector2 screenBounds;
        private Vector3 screenSize;

        private void Awake()
        {
            mainCamera ??= GetComponent<Camera>();
            screenBounds = mainCamera.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height));
            screenSize =
                mainCamera.ScreenToViewportPoint(new Vector3(Screen.width, Screen.height,
                                                             mainCamera.transform.position.z));
            Debug.Log("ScreenSize in container: " + screenSize);

        }

        private void Reset()
        {
            mainCamera ??= GetComponent<Camera>();
        }

        public void InvokeEvents()
        {
            GetScreenBounds?.Invoke(screenBounds);
            GetScreenSize?.Invoke(screenSize);
        }

        public void Subscribe(params Delegate[] subscribers)
        {
            EventExtensions.Subscribe(ref GetScreenBounds, subscribers);
            EventExtensions.Subscribe(ref GetScreenSize, subscribers);
        }

        public void Unsubscribe(params Delegate[] unsubscribers)
        {
            EventExtensions.Subscribe(ref GetScreenBounds, unsubscribers);
            EventExtensions.Subscribe(ref GetScreenSize, unsubscribers);
        }
    }
}
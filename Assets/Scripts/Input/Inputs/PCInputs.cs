using System;
using Base;
using CorePlugin.Cross.Events.Interface;
using CorePlugin.Extensions;
using UnityEngine;

namespace Input.Inputs
{
    public class PCInputs: MonoBehaviour, IEventHandler
    {
        private PlayerControll control;
        private event PlayerEvents.RunVert RunVert;
        private event PlayerEvents.Shoot Shoot;
        private event ScreenStateDelegates.Pause Pause;

        public Vector2 Dir { get; private set; }

        private void OnEnable()
        {
            control ??= new PlayerControll();
            control.Enable();
        }

        private void Start()
        {
            control.PlayerControl.ScreensControl.started += i => Pause?.Invoke();
            control.PlayerControl.Attack.started += i => Shoot?.Invoke();
        }

        private void Update()
        {
            Dir = control.PlayerControl.Movement.ReadValue<Vector2>();
            RunVert?.Invoke(Dir);
        }

        private void OnDisable()
        {
            control.Disable();
        }

        public void InvokeEvents()
        {
        }

        public void Subscribe(params Delegate[] subscribers)
        {
            EventExtensions.Subscribe(ref RunVert, subscribers);
            EventExtensions.Subscribe(ref Shoot, subscribers);
            EventExtensions.Subscribe(ref Pause, subscribers);
        }

        public void Unsubscribe(params Delegate[] unsubscribers)
        {
            EventExtensions.Unsubscribe(ref RunVert, unsubscribers);
            EventExtensions.Unsubscribe(ref Shoot, unsubscribers);
            EventExtensions.Subscribe(ref Pause, unsubscribers);
        }
    }
}
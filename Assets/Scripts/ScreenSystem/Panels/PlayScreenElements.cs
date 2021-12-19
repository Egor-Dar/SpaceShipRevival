using System;
using Base;
using CorePlugin.Core;
using CorePlugin.Cross.Events.Interface;
using CorePlugin.Extensions;
using UnityEngine;
using UnityEngine.UI;

namespace ScreenSystem.Panels
{
    public sealed class PlayScreenElements : MonoBehaviour, IEventHandler
    {
        [SerializeField] private Button pause;
        private event ScreenStateDelegates.Pause PauseEvent;
        private void Start()
        {
            pause.onClick.AddListener(OnPauseEvent);
        }
        public void InvokeEvents()
        {

        }
        public void Subscribe(params Delegate[] subscribers)
        {
            EventExtensions.Subscribe(ref PauseEvent, subscribers);
        }
        public void Unsubscribe(params Delegate[] unsubscribers)
        {
            EventExtensions.Unsubscribe(ref PauseEvent, unsubscribers);
        }
        private void OnPauseEvent()
        {
            PauseEvent?.Invoke();
        }
    }
}

using System;
using Base;
using CorePlugin.Cross.Events.Interface;
using CorePlugin.Extensions;
using UnityEngine;
using UnityEngine.UI;

namespace ScreenSystem.Panels
{
    public sealed class PauseScreenElements : MonoBehaviour, IEventHandler
    {
        [SerializeField] private Button play;
        [SerializeField] private Button pause;
        [SerializeField] private Button restart;
        private event ScreenStateDelegates.Play PlayEvent;
        private event ScreenStateDelegates.Pause PauseEvent;
        private event ScreenStateDelegates.Restart RestartEvent;
        private void OnPlayEvent()
        {
            PlayEvent?.Invoke();
        }
        private void OnPauseEvent()
        {
            PauseEvent?.Invoke();
        }
        private void OnRestartEvent()
        {
            RestartEvent?.Invoke();
        }
        private void Start()
        {
            play.onClick.AddListener(OnPlayEvent);
            pause.onClick.AddListener(OnPauseEvent);
            restart.onClick.AddListener(OnRestartEvent);
        }

        public void InvokeEvents() { }
        public void Subscribe(params Delegate[] subscribers)
        {
            EventExtensions.Subscribe(ref PlayEvent, subscribers);
            EventExtensions.Subscribe(ref PauseEvent, subscribers);
            EventExtensions.Subscribe(ref RestartEvent, subscribers);
        }
        public void Unsubscribe(params Delegate[] unsubscribers)
        {
            EventExtensions.Unsubscribe(ref PlayEvent, unsubscribers);
            EventExtensions.Unsubscribe(ref PauseEvent, unsubscribers);
            EventExtensions.Unsubscribe(ref RestartEvent, unsubscribers);
        }
    }
}

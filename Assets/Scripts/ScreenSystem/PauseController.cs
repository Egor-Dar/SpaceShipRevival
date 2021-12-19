using System;
using System.Collections.Generic;
using Base;
using CorePlugin.Cross.Events.Interface;
using CorePlugin.Extensions;
using Observer;
using UnityEngine;

namespace ScreenSystem
{
    public class PauseController : MonoBehaviour, IObservable, IEventHandler, IEventSubscriber
    {
        private event ScreenStateDelegates.Play Play;
        private event ScreenStateDelegates.Pause Pause;
        private List<IObserver> observers;
        private bool paused;
        public bool IsPaused() { return paused;}

        private void Paused()
        {
            if (paused)
            {
                paused = false;
                Play?.Invoke();
            }
            else
            {
                paused = true;
                Pause?.Invoke();
            }
        }
        
        public void AddObserver(IObserver o)
        {
            observers.Add(o);
        }
        public void RemoveObserver(IObserver o)
        {
            observers.Remove(o);
        }
        public void NotifyObservers()
        {
            foreach (var observer in observers)
            {
                observer.UpdateMSG();
            }
        }

        public void InvokeEvents()
        {
            
        }
        public void Subscribe(params Delegate[] subscribers)
        {
            EventExtensions.Subscribe(ref Play,subscribers);
            EventExtensions.Subscribe(ref Pause,subscribers);
        }
        public void Unsubscribe(params Delegate[] unsubscribers)
        {
            EventExtensions.Unsubscribe(ref Play, unsubscribers);
            EventExtensions.Unsubscribe(ref Pause, unsubscribers);
        }
        public Delegate[] GetSubscribers()
        {
            return new Delegate[]
            {
                (ScreenStateDelegates.Pause) Paused
            };
        }
    }
}

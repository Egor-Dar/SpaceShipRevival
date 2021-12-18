using System;
using CorePlugin.Cross.Events.Interface;
using UnityEngine;
using Base;

namespace Managers.Screen
{
    public class ScreenController : MonoBehaviour, IEventSubscriber
    {
        [SerializeField] private GameObject playScreen;
        [SerializeField] private GameObject pauseScreen;
        [SerializeField] private GameObject dieScreen;
        [SerializeField] private GameObject settingScreen;

        private readonly ScreenState _screenState = new ScreenState();

        private void Play()
        {
            _screenState.SetScreen(playScreen);
            Time.timeScale = 1;
        }

        private void Die()
        {
            _screenState.SetScreen(dieScreen);
        }

        private void Pause()
        {
            _screenState.SetScreen(pauseScreen);
            Time.timeScale = 0;
        }


        private void Settings()
        {
            _screenState.SetScreen(settingScreen);
        }

        public Delegate[] GetSubscribers()
        {
            return new Delegate[]
            {
                (ScreenStateDelegates.Play) Play,
                (ScreenStateDelegates.Die) Die,
                (ScreenStateDelegates.Pause) Pause,
                (ScreenStateDelegates.Setting) Settings
            };
        }
    }
}
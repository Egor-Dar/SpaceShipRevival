using System;
using System.Collections.Generic;
using Base;
using CorePlugin.Attributes.EditorAddons;
using CorePlugin.Cross.Events.Interface;
using Observer;
using Unity.VisualScripting.Dependencies.Sqlite;
using UnityEditor.SceneManagement;
using UnityEngine;

namespace ScreenSystem
{
    [CoreManagerElement]
    public class ScreenController : MonoBehaviour, IEventSubscriber
    {
        [SerializeField] private CanvasGroup playScreenInAndroid;
        [SerializeField] private CanvasGroup playScreenInPC;
        [SerializeField] private GameObject canvas;
        [SerializeField] private CanvasGroup pauseScreen;
        [SerializeField] private CanvasGroup dieScreen;
        //[SerializeField] private CanvasGroup settingScreen; 
        private CanvasGroup playScreen;

        private readonly ScreenState _screenState = new ScreenState();

        private void Awake()
        {
            canvas = Instantiate(canvas, Vector3.zero, Quaternion.identity);
            var canvasPosition = canvas.transform;
            switch (Application.platform)
            {
                case RuntimePlatform.Android:
                    playScreen = Instantiate(playScreenInAndroid, parent: canvasPosition);
                    break;
                default:
                    playScreen = Instantiate(playScreenInPC,parent: canvasPosition);
                    break;
            }
            pauseScreen = Instantiate(pauseScreen, parent: canvasPosition);
            dieScreen = Instantiate(dieScreen, parent: canvasPosition);
            //settingScreen = Instantiate(settingScreen, canvasPosition, Quaternion.identity);

            Play();
        }

        private void Play()
        {
            _screenState.SetScreen(playScreen);
        }

        private void Die()
        {
            _screenState.SetScreen(dieScreen);
        }

        private void Pause()
        {
            _screenState.SetScreen(pauseScreen);
        }


        private void Settings()
        {
            Debug.Log("Settings Panel");
            // _screenState.SetScreen(settingScreen);
        }

        public Delegate[] GetSubscribers()
        {
            return new Delegate[]
            {
                (ScreenStateDelegates.Play) Play,
                (ScreenStateDelegates.Setting) Settings,
                (ScreenStateDelegates.Die) Die,
            };
        }

    }
}

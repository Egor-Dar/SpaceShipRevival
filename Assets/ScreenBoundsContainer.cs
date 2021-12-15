using System;
using System.Collections;
using System.Collections.Generic;
using Base;
using CorePlugin.Cross.Events.Interface;
using CorePlugin.Extensions;
using UnityEngine;

[RequireComponent(typeof(Camera))]
public class ScreenBoundsContainer : MonoBehaviour, IEventHandler
{
    [SerializeField] private Camera mainCamera;
    
    private event GeneralEvents.GetScreenBound GetScreenBounds;
    
    private Vector2 screenBounds;
    
    private void Awake()
    {
        mainCamera ??= GetComponent<Camera>();
        screenBounds = mainCamera.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height));
    }

    private void Reset()
    {
        mainCamera ??= GetComponent<Camera>();
    }

    public void InvokeEvents()
    {
        GetScreenBounds?.Invoke(screenBounds);
    }

    public void Subscribe(params Delegate[] subscribers)
    {
        EventExtensions.Subscribe(ref GetScreenBounds, subscribers);
    }

    public void Unsubscribe(params Delegate[] unsubscribers)
    {
        EventExtensions.Subscribe(ref GetScreenBounds, unsubscribers);
    }
}

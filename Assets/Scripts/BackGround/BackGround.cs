using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using Base;
using CorePlugin.Attributes.EditorAddons;
using CorePlugin.Cross.Events.Interface;
using UnityEngine;
using UnityEngine.Events;

[CoreManagerElement]
public class BackGround : MonoBehaviour, IEventSubscriber
{
    [SerializeField] private Camera MainCamera;
    [SerializeField] private float scrollSpeed;
    [SerializeField] private float tileSize;
    private Vector3 screenSize;

    void Start()
    {
        transform.GetChild(0).transform.localScale =
            new Vector3(screenSize.x * 0.87f, screenSize.y * 0.87f, screenSize.z);
        transform.GetChild(0).GetChild(0).transform.localScale = new Vector3(screenSize.x, screenSize.y, screenSize.z);
    }

    private void ReceiveScreenSize(Vector3 newScreenSize)
    {
        screenSize = newScreenSize;
    }

    void Update()
    {
        transform.position = transform.position - Vector3.right * scrollSpeed * Time.deltaTime;
        if (transform.position.x <= tileSize)
        {
            float result = transform.position.x - tileSize;
            transform.position = new Vector3(result, transform.position.y, transform.position.z);
        }
    }

    public Delegate[] GetSubscribers()
    {
        return new Delegate[]
        {
            (GeneralEvents.GetScreenSize) ReceiveScreenSize
        };
    }
}
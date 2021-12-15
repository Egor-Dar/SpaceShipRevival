using System;
using System.Collections.Generic;
using Base;
using CorePlugin.Cross.Events.Interface;
using JetBrains.Annotations;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

namespace BlueZone
{
    [RequireComponent(typeof(Image))]
    public class HealthContains : MonoBehaviour, IEventSubscriber
    {
        [NotNull] [SerializeField] private Image imageComponent;
        [NotNull] [SerializeField] private Sprite healthFilled, healthNotFilled;
        private Image[] imageHealth;

        private void StartGame(int currentMaxHealth, int maxHealth)
        {
            imageHealth = new Image[maxHealth];
            for (int i = 0; i < maxHealth; i++)
            {
                imageHealth[i] = Instantiate(imageComponent, transform);
                imageHealth[i].color=new Color(1,1,1,0);
            }
            for (int j = 0; j < currentMaxHealth; j++)
            {
                imageHealth[j].color=new Color(1,1,1,1);
                imageHealth[j].sprite = healthFilled;
            }
        }

        private void RemoveContains(int currentHealth,int currentMaxHealth)
        {
            for (int i = currentMaxHealth; i >= currentHealth; i--)
            {
                if(imageHealth[i].sprite!=healthNotFilled) imageHealth[i].sprite = healthNotFilled;
            }
        } 
        private void AddContains(int currentHealth,int currentMaxHealth)
        {
            for (int i =0; i >= currentHealth; i++)
            {
                if(imageHealth[i].sprite!=healthFilled) imageHealth[i].sprite = healthFilled;
            }
        }

        public Delegate[] GetSubscribers()
        {
            return new Delegate[]
            {
                (PlayerEvents.OnPlayerHealthChanged) StartGame,
                (PlayerEvents.OnPlayerHealthAdd) AddContains,
                (PlayerEvents.OnPlayerHealthRemove) RemoveContains
            };
        }
    }
}
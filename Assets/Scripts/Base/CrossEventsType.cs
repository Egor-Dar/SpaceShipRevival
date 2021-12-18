using OrangeZone;
using UnityEngine;
using UnityEngine.Pool;

namespace Base
{
    public static class PlayerEvents
    {
        public delegate void RunVert(Vector2 dir);

        public delegate void Shoot();

        public delegate void SpawnBullets();

        public delegate Vector2 GetCurrentPlayerPosition();

        public delegate void OnPlayerHealthChanged(int currentMaxHealth, int maxHealth);

        public delegate void OnPlayerHealthRemove(int currentHealth, int currentMaxHealth);

        public delegate void OnPlayerHealthAdd(int currentHealth, int currentMaxHealth);
    }

    public static class GeneralEvents
    {
        public delegate void GetScreenBound(Vector2 screenBounds);
        public delegate void GetScreenSize(Vector3 screenSize);
    }

    public static class PoolDelegates
    {
        public delegate void ReleasePoolObjectObstacles(IPoolObject poolObject);

        public delegate void ReleasePoolObjectBullets(IPoolObject poolObject);
    }

    public static class ScreenStateDelegates
    {
        public delegate void Play();
        public delegate void Die();
        public delegate void Pause();
        public delegate void Setting();
    }
}
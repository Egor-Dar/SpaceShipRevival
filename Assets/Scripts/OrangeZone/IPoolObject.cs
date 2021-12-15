using System;
using UnityEngine;

namespace OrangeZone
{
    public interface IPoolObject
    {
        public void SetActive(bool state);
        public void ResetState();
        public void Destroy();
        public void Initialize(Action<IPoolObject> onRelease);
        public IPoolObject Instantiate();
        public void SetPosition(Vector3 newPos);
    }
}
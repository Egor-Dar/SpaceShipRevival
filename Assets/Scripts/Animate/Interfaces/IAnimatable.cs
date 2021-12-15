using System;
using Base;
using CorePlugin.Attributes.EditorAddons;
using CorePlugin.Cross.Events.Interface;
using UnityEngine;

namespace Animate
{
    public interface IAnimatable<in T>
    {
        public IAnimatable<T> Initialize(Animator animator);
        public void Run(T parameters);
    }
    
    public interface IAnimatable
    {
        public IAnimatable Initialize(Animator animator);
        public void Run();
    }
}
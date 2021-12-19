using UnityEngine;

namespace Animate.Interfaces
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
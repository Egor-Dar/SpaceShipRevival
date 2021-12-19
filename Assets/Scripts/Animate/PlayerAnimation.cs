using Animate.Interfaces;
using UnityEngine;

namespace Animate
{
    public class PlayerAnimation : IAnimatable<Vector2>
    {
        private static readonly int Down = Animator.StringToHash("Down");
        private static readonly int Up = Animator.StringToHash("Up");

        private Animator _anim;

        public void Run(Vector2 dir)
        {
            if (Vector2.Dot(dir, Vector2.down) >= 1f)
            {
                _anim.SetBool(Down, true);
                return;
            }

            if (Vector2.Dot(dir, Vector2.up) >= 1f)
            {
                _anim.SetBool(Up, true);
                return;
            }

            _anim.SetBool(Up, false);
            _anim.SetBool(Down, false);
        }

        public IAnimatable<Vector2> Initialize(Animator animator)
        {
            _anim = animator;
            return this;
        }
    }
}
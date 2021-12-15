using System;
using Base;
using CorePlugin.Cross.Events.Interface;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Animate
{
    public class ObstacleAnimation : IAnimatable<Transform>
    {
        private Animator anim;
        private static int DieAnimation = Animator.StringToHash("DieAnimation");

        public IAnimatable<Transform> Initialize(Animator animator)
        {
            anim = animator;
            return this;
        }

        public void Run(Transform parameters)
        {
            var animator = Object.Instantiate(anim, parameters.position, parameters.rotation, parameters.parent);
            animator.Play(DieAnimation);
            Object.Destroy(animator.gameObject, animator.GetCurrentAnimatorStateInfo(0).length);
        }
    }
}
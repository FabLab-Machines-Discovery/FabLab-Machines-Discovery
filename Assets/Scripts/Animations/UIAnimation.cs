using System;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.Serialization;

namespace Animations
{
    public abstract class UIAnimation<TDesiredValue> : MonoBehaviour
    {
        public bool onStart;
        public UIAnimationProps<TDesiredValue> animationProps;

        protected Tween tween;

        protected virtual void Start()
        {
            if (onStart)
            {
                PlayAnimation();
            }
        }

        public abstract void PlayAnimation();
        public abstract void ResetAnimation();
    }
}
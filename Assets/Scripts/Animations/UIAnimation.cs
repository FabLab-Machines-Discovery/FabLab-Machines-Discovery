using System;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.Serialization;

namespace Animations
{
    public abstract class UIAnimation<TDesiredValue> : MonoBehaviour
    {
        [Tooltip("Whether to play animation on start or not")]
        public bool onStart;
        
        public UIAnimationProps<TDesiredValue> animationProps;

        // Used to store the tween for the animation, so you can kill it later
        protected Tween tween;

        protected virtual void Start()
        {
            if (onStart)
            {
                PlayAnimation();
            }
        }
        
        // Start the animation tween
        public abstract void PlayAnimation();
        
        // Resets the animatable component to its original state and kills the tween
        public virtual void ResetAnimation()
        {
            // Kill the tween and reset the fill amount of image to its initial value
            tween?.Kill();
        }
    }
}
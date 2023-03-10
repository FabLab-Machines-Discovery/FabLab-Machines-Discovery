using UnityEngine;
using DG.Tweening;

namespace Animations
{
    public interface IUIAnimation
    {
        public void Play();
    }
    
    public abstract class UIAnimation<TDesiredValue> : MonoBehaviour, IUIAnimation
    {
        // Properties used for animation
        [SerializeField] protected UIAnimationProps<TDesiredValue> animationProps;

        // Used to store the tween for the animation, so you can kill it later
        protected Tween tween;

        protected virtual void Start()
        {
            if(animationProps.autoPlay) Play();
        }

        /// <summary>
        /// Starts the animation.
        /// </summary>
        public abstract void Play();

        // Kill the tween when the object is disabled or destroyed
        protected void OnDisable()
        {
            tween?.Kill();

        }
    }
}
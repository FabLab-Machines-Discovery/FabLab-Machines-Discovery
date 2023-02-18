using UnityEngine;
using DG.Tweening;

namespace Animations
{
    public interface IUIAnimation
    {
        void PlayAnimation();
        void ResetObj();
    }
    public abstract class UIAnimation<TDesiredValue> : MonoBehaviour, IUIAnimation
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
        
        // Prepare the game object for the animation
        public abstract void PrepareObj();
        
        // Start the animation tween
        public abstract void PlayAnimation();
        
        // Resets the game object to its original state and kills the tween
        public virtual void ResetObj()
        {
            // Kill the tween and reset the fill amount of image to its initial value
            tween?.Kill();
        }
    }
}
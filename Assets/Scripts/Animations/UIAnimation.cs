using UnityEngine;
using DG.Tweening;
using Onboarding_Scene;

namespace Animations
{
    // Interface used for the custom editor because UIAnimation is a generic class
    public interface IUIAnimation
    {
        void PlayAnimation();
        void ResetObj();
    }
    public abstract class UIAnimation<TDesiredValue> : MonoBehaviour, IUIAnimation
    {
        // Properties used for animation
        public UIAnimationProps<TDesiredValue> animationProps;

        // Used to store the tween for the animation, so you can kill it later
        protected Tween tween;

        protected virtual void Start()
        {
            if (animationProps.startProps.when == AnimationStartType.OnStart)
            {
                PlayAnimation();
            }
            else
            {
                PanelSwiper.OnSwipe += PlayAnimationOnSwipe;
            }
        }

        // Prepare the game object for the animation
        public abstract void PrepareObj();
        
        // Start the animation tween
        public abstract void PlayAnimation();

        private void PlayAnimationOnSwipe(int panelIndex)
        {
            if (animationProps.startProps.panelIndex != panelIndex) return;
            
            PlayAnimation();
            PanelSwiper.OnSwipe -= PlayAnimationOnSwipe;
        }
        
        // Resets the game object to its original state and kills the tween
        public virtual void ResetObj()
        {
            // Kill the tween and reset the fill amount of image to its initial value
            tween?.Kill();
        }
    }
}
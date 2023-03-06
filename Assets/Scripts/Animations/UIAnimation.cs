using UnityEngine;
using DG.Tweening;
using Onboarding_Scene;

namespace Animations
{
    public abstract class UIAnimation<TDesiredValue> : MonoBehaviour
    {
        // Properties used for animation
        public UIAnimationProps<TDesiredValue> animationProps;

        // Used to store the tween for the animation, so you can kill it later
        protected Tween tween;

        protected virtual void Start()
        {
            if (animationProps.startProps.when == AnimationStartType.OnStart)
            {
                Play();
            }
            else
            {
                PanelSwiper.OnSwipe += PlayOnSwipe;
            }
        }

        // Start the animation tween
        public abstract void Play();

        // Start the animation when the swipe event is invoked
        private void PlayOnSwipe(int panelIndex)
        {
            if (animationProps.startProps.panelIndex != panelIndex) return;
            
            Play();
            PanelSwiper.OnSwipe -= PlayOnSwipe;
        }

        // Kill the tween when the object is disabled or destroyed
        protected void OnDisable()
        {
            tween?.Kill();

        }
    }
}
using UnityEngine;
using DG.Tweening;

namespace Animations
{
    public class ImageWipeAnimation : ImageAnimation<float>
    {
        // Used to store the initial fill amount of the image
        private float _initialFillAmount;

        protected override void Awake()
        {
            base.Awake();
            _initialFillAmount = image.fillAmount;
        }

        public override void PlayAnimation()
        {
            // Change the fill amount of the image to desired value, while applying provided duration and delay
            // Store a reference to it in tween 
            tween = image.DOFillAmount(animationProps.desiredValue, animationProps.duration)
                .SetDelay(animationProps.delay);
        }

        public override void ResetAnimation()
        {
            // Kill the tween and reset the fill amount of image to its initial value
            tween.Kill();
            image.fillAmount = _initialFillAmount;
        }
    }
}
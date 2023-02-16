using UnityEngine;
using DG.Tweening;

namespace Animations
{
    public class ImageFadeAnimation : ImageAnimation<float>
    {
        // Used to store the initial alpha of the image
        private float _initialAlpha;

        protected override void Awake()
        {
            base.Awake();
            _initialAlpha = image.color.a;
        }

        public override void PlayAnimation()
        {
            // Change the alpha of image to desired value, while applying provided duration and delay
            // Store a reference to it in tween 
            tween = image.DOFade(animationProps.desiredValue, animationProps.duration)
                    .SetDelay(animationProps.delay);
        }

        public override void ResetAnimation()
        {
            // Kill the tween and reset the image alpha to its initial value
            tween.Kill();
            image.color = new Color(image.color.r, image.color.g, image.color.b, _initialAlpha);
        }
    }
}
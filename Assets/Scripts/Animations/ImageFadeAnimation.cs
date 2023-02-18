using UnityEngine;
using DG.Tweening;

namespace Animations
{
    public class ImageFadeAnimation : ImageAnimation<AnimationMode>
    {
        public override void PlayAnimation()
        {
            // Set image properties
            image.color = new Color(image.color.r, image.color.g, image.color.b, 1 - (int)animationProps.desiredValue);
            
            // Change the alpha of image to desired value, while applying provided duration and delay
            // Store a reference to it in tween 
            tween = image.DOFade((int)animationProps.desiredValue, animationProps.duration)
                    .SetDelay(animationProps.delay);
        }

        public override void ResetAnimation()
        {
            base.ResetAnimation();
            image.color = new Color(image.color.r, image.color.g, image.color.b, 1 - (int)animationProps.desiredValue);
        }
    }
}
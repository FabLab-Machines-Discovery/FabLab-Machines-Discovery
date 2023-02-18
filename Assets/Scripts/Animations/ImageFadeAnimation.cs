using UnityEngine;
using DG.Tweening;

namespace Animations
{
    public class ImageFadeAnimation : ImageAnimation<AnimationMode>
    {
        public override void PrepareObj()
        {
            // Set image properties
            image.color = new Color(image.color.r, image.color.g, image.color.b, 1 - (int)animationProps.desiredValue);
        }

        public override void PlayAnimation()
        {
            // Change the alpha of image to desired value, while applying provided duration and delay
            // Store a reference to it in tween 
            tween = image.DOFade((int)animationProps.desiredValue, animationProps.duration)
                    .SetDelay(animationProps.delay)
                    .OnStart(PrepareObj);
        }

        public override void ResetObj()
        {
            base.ResetObj();
            image.color = new Color(image.color.r, image.color.g, image.color.b, 1 - (int)animationProps.desiredValue);
        }
    }
}
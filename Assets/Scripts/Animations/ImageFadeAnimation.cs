using DG.Tweening;

namespace Animations
{
    public class ImageFadeAnimation : ImageAnimation<AnimationMode>
    {
        public override void Play()
        {
            // Change the alpha of image to desired value, while applying provided duration and delay
            // Store a reference to it in tween 
            tween = image.DOFade((int)animationProps.desiredValue, animationProps.duration)
                .SetDelay(animationProps.delay);
        }
    }
}
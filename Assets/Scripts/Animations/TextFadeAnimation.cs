using DG.Tweening;

namespace Animations
{
    public class TextFadeAnimation : TextAnimation<AnimationMode>
    {
        public override void Play()
        {
            // Change the alpha of textMesh to desired value, while applying provided duration and delay
            // Store a reference to it in tween 
            tween = DOTween.To(() => textMesh.alpha, x => textMesh.alpha = x,
                    (int)animationProps.desiredValue, animationProps.duration)
                .SetDelay(animationProps.delay);
        }
    }
}
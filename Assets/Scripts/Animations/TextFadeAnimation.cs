using UnityEngine;
using DG.Tweening;

namespace Animations
{
    public class TextFadeAnimation : TextAnimation<AnimationMode>
    {
        public override void PrepareObj()
        {
            // Set text alpha
            textMesh.alpha = 1 - (int)animationProps.desiredValue;
        }

        public override void PlayAnimation()
        {
            // Change the alpha of textMesh to desired value, while applying provided duration and delay
            // Store a reference to it in tween 
            tween = DOTween.To(() => textMesh.alpha, x => textMesh.alpha = x,
                (int)animationProps.desiredValue, animationProps.duration)
                .SetDelay(animationProps.delay)
                .OnStart(PrepareObj);
        }

        public override void ResetObj()
        {
            base.ResetObj();
            PrepareObj();
        }
    }
}
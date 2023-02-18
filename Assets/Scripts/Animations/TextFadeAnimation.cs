using UnityEngine;
using DG.Tweening;

namespace Animations
{
    public class TextFadeAnimation : TextAnimation<AnimationMode>
    {
        public override void PlayAnimation()
        {
            // Set text properties
            textMesh.color = new Color(textMesh.color.r, textMesh.color.g, textMesh.color.b,
                1 - (int)animationProps.desiredValue);
            
            // Change the alpha of textMesh to desired value, while applying provided duration and delay
            // Store a reference to it in tween 
            tween = DOTween.To(() => textMesh.color, x => textMesh.color = x,
                    new Color(textMesh.color.r, textMesh.color.g, textMesh.color.b, (int)animationProps.desiredValue),
                    animationProps.duration)
                .SetOptions(true)
                .SetDelay(animationProps.delay);
        }

        public override void ResetAnimation()
        {
            base.ResetAnimation();
            textMesh.color = new Color(textMesh.color.r, textMesh.color.g, textMesh.color.b, 1 - (int)animationProps.desiredValue);
        }
    }
}
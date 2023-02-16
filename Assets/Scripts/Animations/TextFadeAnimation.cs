using UnityEngine;
using DG.Tweening;

namespace Animations
{
    public class TextFadeAnimation : TextAnimation<float>
    {
        // Used to store the initial alpha of textMesh
        private float _initialAlpha;

        protected override void Awake()
        {
            base.Awake();
            _initialAlpha = textMesh.color.a;
        }

        public override void PlayAnimation()
        {
            // Change the alpha of textMesh to desired value, while applying provided duration and delay
            // Store a reference to it in tween 
            tween = DOTween.To(() => textMesh.color, x => textMesh.color = x,
                    new Color(textMesh.color.r, textMesh.color.g, textMesh.color.b, animationProps.desiredValue),
                    animationProps.duration)
                .SetOptions(true)
                .SetDelay(animationProps.delay);
        }

        public override void ResetAnimation()
        {
            // Kill the tween and reset the textMesh alpha to its initial value
            tween.Kill();
            textMesh.color = new Color(textMesh.color.r, textMesh.color.g, textMesh.color.b, _initialAlpha);
        }
    }
}
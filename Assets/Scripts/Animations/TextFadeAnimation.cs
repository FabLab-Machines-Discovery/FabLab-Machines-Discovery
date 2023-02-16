using UnityEngine;
using DG.Tweening;

namespace Animations
{
    public class TextFadeAnimation : TextAnimation<float>
    {
        private float _initialAlpha;

        protected override void Awake()
        {
            base.Awake();
            _initialAlpha = textMesh.color.a;
        }

        public override void PlayAnimation()
        {
            tween = DOTween.To(() => textMesh.color, x => textMesh.color = x,
                    new Color(textMesh.color.r, textMesh.color.g, textMesh.color.b, animationProps.desiredValue),
                    animationProps.duration)
                .SetOptions(true)
                .SetDelay(animationProps.delay);
        }

        public override void ResetAnimation()
        {
            tween.Kill();
            textMesh.color = new Color(textMesh.color.r, textMesh.color.g, textMesh.color.b, _initialAlpha);
        }
    }
}
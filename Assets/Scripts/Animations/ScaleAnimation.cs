using System;
using DG.Tweening;
using UnityEngine;

namespace Animations
{
    public class ScaleAnimation : UIAnimation<Vector3>
    {
        private RectTransform _rectTransform;
        public override void Play()
        {
            tween = _rectTransform.DOScale(animationProps.desiredValue,animationProps.duration)
                .SetDelay(animationProps.delay);
        }

        private void Awake()
        {
            _rectTransform = GetComponent<RectTransform>();
        }
    }
}
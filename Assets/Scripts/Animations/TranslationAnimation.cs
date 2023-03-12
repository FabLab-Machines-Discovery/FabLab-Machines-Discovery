using UnityEngine;
using DG.Tweening;

namespace Animations
{
    public class TranslationAnimation : UIAnimation<Vector3>
    {
        private RectTransform _rectTransform;
        public override void Play()
        {
            //Get Initial position of the component
            _rectTransform = GetComponent<RectTransform>();
            //Store a reference to it in tween 
            tween = _rectTransform.DOLocalMove(animationProps.desiredValue,animationProps.duration).SetRelative()
                .SetDelay(animationProps.delay);
        }
        
    }
}
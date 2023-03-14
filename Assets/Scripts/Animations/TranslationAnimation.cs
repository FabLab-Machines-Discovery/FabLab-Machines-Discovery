using UnityEngine;
using DG.Tweening;

namespace Animations
{
    public class TranslationAnimation : UIAnimation<Vector3>
    {
        public override void Play()
        {
            //Change the position to desired value, while applying provided duration and delay
            //Store a reference to it in tween 
            tween = transform.DOLocalMove(animationProps.desiredValue,animationProps.duration).SetRelative()
                .SetDelay(animationProps.delay);
        }
        
    }
}
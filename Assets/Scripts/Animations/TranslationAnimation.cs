using UnityEngine;
using DG.Tweening;

namespace Animations
{
    public class TranslationAnimation : UIAnimation<Vector3>
    {
        [Tooltip("Whether the translation is relative to the object's local position or not\n" +
                 "If set to false, it will translate towards the desired value\n" +
                 "If set to true, it will add the desired value to the object's local position\n")]
        public bool isRelative = true;
        public override void Play()
        {
            //Change the position to desired value, while applying provided duration and delay
            //Store a reference to it in tween 
            tween = transform.DOLocalMove(animationProps.desiredValue,animationProps.duration)
                .SetRelative(isRelative)
                .SetDelay(animationProps.delay);
        }
        
    }
}
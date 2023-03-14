
using DG.Tweening;
using UnityEngine;


namespace Animations
{
    public class ScaleAnimation : UIAnimation<Vector3>
    {
        public override void Play()
        {
            //Change the scale to desired value, while applying provided duration and delay
            //Store a reference to it in tween 
            tween = transform.DOScale(animationProps.desiredValue,animationProps.duration)
                .SetDelay(animationProps.delay);
        }
    }
}
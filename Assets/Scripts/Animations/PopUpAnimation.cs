using System;
using UnityEngine;
using DG.Tweening;
namespace Animations
{
    public class PopUpAnimation : UIAnimation<Vector3>
    {
        [Tooltip("Controls how visible the pop effect is : the higher the value, the less visible")]
        [Range(2,10)]
        public int divider = 2;
        public override void Play()
        {
            
            //Change the scale to desired value with a popUp effect, while applying provided duration and delay 
            //Store a reference to it in tween 
            if (animationProps.desiredValue.magnitude > transform.localScale.magnitude)
            {
                
                tween = transform.DOScale(animationProps.desiredValue+animationProps.desiredValue/divider, animationProps.duration)
                    .SetDelay(animationProps.delay).OnComplete(() =>
                    {
                        transform.DOScale(animationProps.desiredValue, animationProps.duration);
                    });
                
            }
            else
            {
                tween = transform.DOScale(animationProps.desiredValue-animationProps.desiredValue/divider,animationProps.duration)
                    .SetDelay(animationProps.delay).OnComplete(() =>
                    {
                        transform.DOScale(animationProps.desiredValue, animationProps.duration);
                    });
            }
        }

       
    }
}
using System;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

namespace Animations
{
    public class ImageWipeAnimation : ImageAnimation<AnimationMode>
    {
        [Tooltip("Method with which the wipe mask should be animated")]
        public Image.FillMethod wipeFillMethod;
        
        [Tooltip("Mode with which the wipe mask should be animated")]
        public WipeType wipeType;

        public override void PrepareObj()
        {
            // Set image properties
            image.type = Image.Type.Filled;
            image.fillMethod = wipeFillMethod;
            image.fillOrigin = (int)wipeType;
            image.fillAmount = 1f - (int)animationProps.desiredValue;
        }

        public override void PlayAnimation()
        {
            // Change the fill amount of the image to desired value, while applying provided duration and delay
            // Store a reference to it in tween 
            tween = image.DOFillAmount((int)animationProps.desiredValue, animationProps.duration)
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
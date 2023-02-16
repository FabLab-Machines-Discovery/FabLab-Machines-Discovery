using System;
using UnityEngine;

namespace Animations
{
    [Serializable]
    /*
     * UIAnimationProps is a generic class that's used to express the properties any animation needs.
     * desiredValue can be of any type depending on situation: float, color, vector..
     */
    public class UIAnimationProps<TDesiredValue>
    {
        [Tooltip("The value you want to animate to")] 
        public TDesiredValue desiredValue;
        
        [Tooltip("How long the animation take to complete")] 
        public float duration;
        
        [Tooltip("How long to wait before starting the animation")] 
        public float delay;
    }
}
using System;
using UnityEngine;

namespace Animations
{
    [Serializable]
    public class UIAnimationProps<TDesiredValue>
    {
        [Tooltip("Whether to play the animation on start or not")]
        public bool autoPlay = true;
        
        [Tooltip("The value you want to animate to")] 
        public TDesiredValue desiredValue;
        
        [Tooltip("How long the animation take to complete")] 
        public float duration;
        
        [Tooltip("How long to wait before starting the animation")] 
        public float delay;
    }
    
    public enum WipeType {Normal = 0, Alternative = 1}
    public enum AnimationMode {Out = 0, In = 1}
}
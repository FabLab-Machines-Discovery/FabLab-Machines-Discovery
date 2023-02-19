using System;
using UnityEngine;

namespace Animations
{
    [Serializable]
    public class UIAnimationStartProps
    {
        [Tooltip("Whether to play animation on start or on panel swipe")]
        public AnimationStartType when;
        
        [Tooltip("Only needed when using panel swipe")]
        public int panelIndex;
    }
    
    [Serializable]
    public class UIAnimationProps<TDesiredValue>
    {
        public UIAnimationStartProps startProps;
        
        [Tooltip("The value you want to animate to")] 
        public TDesiredValue desiredValue;
        
        [Tooltip("How long the animation take to complete")] 
        public float duration;
        
        [Tooltip("How long to wait before starting the animation")] 
        public float delay;
    }
    
    public enum WipeType {Normal = 0, Alternative = 1}
    public enum AnimationMode {Out = 0, In = 1}
    public enum AnimationStartType {OnStart, OnPanelSwipe}
}
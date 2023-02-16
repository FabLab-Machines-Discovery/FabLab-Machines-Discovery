using System;
using System.ComponentModel;
using UnityEngine;

namespace Animations
{
    [Serializable]
    public class UIAnimationProps<TDesiredValue>
    {
        public TDesiredValue desiredValue;
        public float duration;
        public float delay;
    }
}
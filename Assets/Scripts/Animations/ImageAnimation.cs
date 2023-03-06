using UnityEngine;
using UnityEngine.UI;

namespace Animations
{
    public abstract class ImageAnimation<TDesiredValue> : UIAnimation<TDesiredValue>
    {
        // Required component for image animations
        protected Image image;
        protected virtual void Awake()
        {
            image = GetComponent<Image>();
            if (!image)
            {
                Debug.LogWarning("Can't find Image component on " + gameObject.name);
            }
        }
    }
}
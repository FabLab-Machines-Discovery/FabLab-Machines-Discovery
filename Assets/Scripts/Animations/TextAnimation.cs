using System;
using TMPro;
using UnityEngine;

namespace Animations
{
    public abstract class TextAnimation<TDesiredValue> : UIAnimation<TDesiredValue>
    {
        // Required component for text animations
        protected TextMeshProUGUI textMesh;
        protected virtual void Awake()
        {
            textMesh = GetComponent<TextMeshProUGUI>();
            if (!textMesh)
            {
                Debug.LogWarning("Can't find TextMeshPro component on " + gameObject.name);
            }
        }
    }
}
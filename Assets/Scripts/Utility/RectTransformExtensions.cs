using UnityEngine;

namespace Utility
{
    public static class RectTransformExtensions
    {
        public static void SetLeft(RectTransform rt, float left)
        {
            rt.offsetMin = new Vector2(left, rt.offsetMin.y);
        }
 
        public static void SetRight(RectTransform rt, float right)
        {
            rt.offsetMax = new Vector2(-right, rt.offsetMax.y);
        }
 
        public static void SetTop(RectTransform rt, float top)
        {
            rt.offsetMax = new Vector2(rt.offsetMax.x, -top);
        }
 
        public static void SetBottom(RectTransform rt, float bottom)
        {
            rt.offsetMin = new Vector2(rt.offsetMin.x, bottom);
        }

        public static void SetAll(RectTransform rt, float all)
        {
            SetLeft(rt, all);
            SetRight(rt, all);
            SetTop(rt, all);
            SetBottom(rt, all);
        }
    }
}
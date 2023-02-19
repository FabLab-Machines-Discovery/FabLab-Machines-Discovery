using System;
using UnityEngine;
using UnityEngine.EventSystems;
using DG.Tweening;

namespace Onboarding_Scene
{
    [DefaultExecutionOrder(-1)]
    public class PanelSwiper : MonoBehaviour, IDragHandler, IEndDragHandler
    {
        [Tooltip("At what percentage threshold should I swipe to the next panel automatically")]
        [Range(0, 1)] public float swipeThreshold;
        
        [Tooltip("Duration it takes to smoothly swipe to another panel")]
        [Range(0, 1)] public float swipeDuration;
        public static event Action<int> OnSwipe;

        private readonly float _swipeDistance = Screen.width / 2f;
        private Vector3 _startPosition;
        private int _currentPanel;

        private void Start()
        {
            SetPosition();
        }
        private static void InvokeOnSwipe(int panelIndex)
        {
            OnSwipe?.Invoke(panelIndex);
        }

        private void SetPosition()
        {
            var width = transform.GetChild(0).GetComponent<RectTransform>().rect.width;
            
            for (int i = 0; i < transform.childCount; i++)
            {
                var rt = (RectTransform) transform.GetChild(i);
                Utility.RectTransformExtensions.SetLeft(rt, width * i);
                Utility.RectTransformExtensions.SetRight(rt, -width * i);
            }
            
            _startPosition = transform.position;
        }

        public void OnDrag(PointerEventData data)
        {
            var movement = data.pressPosition.x - data.position.x;
            float xPos;
            
            if (_currentPanel == 0)
            {
                xPos = Mathf.Clamp(_startPosition.x - movement, _startPosition.x - _swipeDistance, _startPosition.x);
            } else if (_currentPanel == transform.childCount - 1)
            {
                xPos = Mathf.Clamp(_startPosition.x - movement, _startPosition.x, _startPosition.x + _swipeDistance);
            }
            else
            {
                xPos = Mathf.Clamp(_startPosition.x - movement, _startPosition.x - _swipeDistance,
                    _startPosition.x + _swipeDistance);
            }
            
            transform.position = new Vector3(xPos, _startPosition.y, _startPosition.z);
        }

        public void OnEndDrag(PointerEventData data)
        {
            var threshold = (data.pressPosition.x - data.position.x) / Screen.width;

            if (Mathf.Abs(threshold) >= swipeThreshold)
            {
                if (threshold > 0 && _currentPanel < transform.childCount - 1)
                {
                    _startPosition.x -= Screen.width;
                    InvokeOnSwipe(++_currentPanel);
                }
                else if (threshold < 0 && _currentPanel > 0)
                {
                    _startPosition.x += Screen.width;
                    InvokeOnSwipe(--_currentPanel);
                }
            }

            transform.DOMoveX(_startPosition.x, swipeDuration);
        }
    }
}
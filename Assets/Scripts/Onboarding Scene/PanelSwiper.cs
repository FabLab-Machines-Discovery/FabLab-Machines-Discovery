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
        
        /// <summary>
        /// Event called when a swipe happens.
        /// </summary>
        public event Action<int> OnSwipe;

        // Distance that a single swipe is allowed
        private readonly float _swipeDistance = Screen.width / 2f;
        
        // Start position of this 
        private Vector3 _startPosition;
        
        // Index of the current swipeable panel in the hierarchy
        private int _currentPanelIndex = 0;

        private void Start()
        {
            SetupPanelPositions();
            InvokeOnSwipe(_currentPanelIndex);
        }
        
        private void InvokeOnSwipe(int panelIndex)
        {
            OnSwipe?.Invoke(panelIndex);
        }
        
        /*
         * Sets up the swipeable panels' positions so that they are adjacent to each other with no space in between.
         * This was necessary because depending on the screen resolution, the panels would sometimes have empty
         * spaces between them, and that would mess up the design and the swipe logic
         */
        private void SetupPanelPositions()
        {
            // Get width of the first panel
            var width = transform.GetChild(0).GetComponent<RectTransform>().rect.width;
            
            // Since panels are of the same size, use that width to adjust the positions of the panels
            for (int i = 0; i < transform.childCount; i++)
            {
                var rt = (RectTransform) transform.GetChild(i);
                Utility.RectTransformExtensions.SetLeft(rt, width * i);
                Utility.RectTransformExtensions.SetRight(rt, -width * i);
            }
            
            // Set the start position of this, which owns the swipeable panels
            _startPosition = transform.position;
        }

        // When the user is dragging, this will be called every time the pointer is moved on the screen
        public void OnDrag(PointerEventData data)
        {
            // Difference in the x value when dragging
            var movement = data.pressPosition.x - data.position.x;
            // Only care about updating the x value of the Transform when dragging
            float xPos;
            
            // If it's the first panel, only allow swiping to the right
            // If it's the last panel, only allow swiping to the left
            // Otherwise allow swiping both ways
            if (_currentPanelIndex == 0)
            {
                xPos = Mathf.Clamp(_startPosition.x - movement, _startPosition.x - _swipeDistance, _startPosition.x);
            } else if (_currentPanelIndex == transform.childCount - 1)
            {
                xPos = Mathf.Clamp(_startPosition.x - movement, _startPosition.x, _startPosition.x + _swipeDistance);
            }
            else
            {
                xPos = Mathf.Clamp(_startPosition.x - movement, _startPosition.x - _swipeDistance,
                    _startPosition.x + _swipeDistance);
            }
            
            // Update the x value of Transform when dragging
            transform.position = new Vector3(xPos, _startPosition.y, _startPosition.z);
        }

        // Called when the user stopped dragging
        public void OnEndDrag(PointerEventData data)
        {
            // How much of the screen was dragged
            var threshold = (data.pressPosition.x - data.position.x) / Screen.width;

            // If it exceeds the threshold, tween to the position of the next swipeable panel
            // Otherwise tween back to the position of the current swipeable panel
            if (Mathf.Abs(threshold) >= swipeThreshold)
            {
                if (threshold > 0 && _currentPanelIndex < transform.childCount - 1)
                {
                    _startPosition.x -= Screen.width;
                    InvokeOnSwipe(++_currentPanelIndex);
                }
                else if (threshold < 0 && _currentPanelIndex > 0)
                {
                    _startPosition.x += Screen.width;
                    InvokeOnSwipe(--_currentPanelIndex);
                }
            }
            transform.DOMoveX(_startPosition.x, swipeDuration);
        }
    }
}
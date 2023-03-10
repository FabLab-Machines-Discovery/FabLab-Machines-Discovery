using UnityEngine;
using UnityEngine.UI;

namespace Onboarding_Scene
{
    public class PanelPagination : MonoBehaviour
    {
        [Tooltip("The PanelSwiper component that the pagination is applying to")]
        public PanelSwiper panelSwiper;
        
        [Tooltip("Color applied for the current/active panel")]
        public Color activeColor;
        
        [Tooltip("Color applied for the other panels")]
        public Color inactiveColor;
        
        // List of dots that represent the panels respectively and are used for pagination
        private Image[] _dots;
        
        private void Start()
        {
            _dots = GetComponentsInChildren<Image>();
            // Subscribe to the OnSwipe event
            panelSwiper.OnSwipe += UpdatePagination;
        }

        private void OnDisable()
        {
            // Unsubscribe of the OnSwipe event
            panelSwiper.OnSwipe -= UpdatePagination;
        }
        
        /*
         * Updates the color of the dots that represent the panels respectively.
         * The dot that represents the active panel will have the activeColor applied to it.
         * The dots that represent the other panels will have the inactiveColor applied to them.
         */
        private void UpdatePagination(int activePanelIndex)
        {
            for (int i = 0; i < _dots.Length; i++)
            {
                _dots[i].color = i == activePanelIndex ? activeColor : inactiveColor;
            }
        }
    }
}
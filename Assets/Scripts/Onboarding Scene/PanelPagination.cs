using UnityEngine;
using UnityEngine.UI;

namespace Onboarding_Scene
{
    public class PanelPagination : MonoBehaviour
    {
        [Tooltip("The PanelSwiper component that the pagination is applying to")]
        [SerializeField] private PanelSwiper panelSwiper;
        
        [Tooltip("Color applied for the current/active panel")]
        [SerializeField] private Color activeColor;
        
        [Tooltip("Color applied for the other panels")]
        [SerializeField] private Color inactiveColor;
        
        // List of dots that represent the panels respectively and are used for pagination
        private Image[] _dots;
        
        private void Start()
        {
            _dots = GetComponentsInChildren<Image>();
            
            // Subscribe to the OnSwipe event
            panelSwiper.OnSwipe += UpdatePagination;
        }

        // Unsubscribes from the OnSwipe event on disable
        private void OnDisable()
        {
            panelSwiper.OnSwipe -= UpdatePagination;
        }
        
        // Updates the color of the dots that represent the panels respectively.
        private void UpdatePagination(int activePanelIndex)
        {
            for (int i = 0; i < _dots.Length; i++)
            {
                _dots[i].color = i == activePanelIndex ? activeColor : inactiveColor;
            }
        }
    }
}
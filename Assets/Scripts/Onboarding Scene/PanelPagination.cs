using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Onboarding_Scene
{
    public class PanelPagination : MonoBehaviour
    {
        public Color activeColor;
        public Color inactiveColor;
        
        private Image[] _dots;
        private void Start()
        {
            _dots = GetComponentsInChildren<Image>();
            PanelSwiper.OnSwipe += SetPagination;
        }

        private void OnDisable()
        {
            PanelSwiper.OnSwipe -= SetPagination;
        }

        private void SetPagination(int panelIndex)
        {
            for (int i = 0; i < _dots.Length; i++)
            {
                _dots[i].color = i == panelIndex ? activeColor : inactiveColor;
            }
        }
    }
}
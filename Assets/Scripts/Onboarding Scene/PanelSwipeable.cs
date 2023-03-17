using Animations;
using UnityEngine;

namespace Onboarding_Scene
{
    public class PanelSwipeable : MonoBehaviour
    {
        [Tooltip("The PanelSwiper component that owns this swipeable panel")]
        public PanelSwiper owner;

        // Index of this swipeable panel in the hierarchy
        private int _index;
        
        // The animations this should play when it's swiped to
        private IUIAnimation[] _animations;

        private void Awake()
        {
            _index = transform.GetSiblingIndex();
            _animations = GetComponentsInChildren<IUIAnimation>();
            owner.OnSwipe += PlayAnimations;
        }

        // Plays the animations when this panel is swiped to, then unsubscribes from the OnSwipe event
        private void PlayAnimations(int index)
        {
            if (_index != index) return;
            
            foreach (var uiAnimation in _animations)
            {
                uiAnimation.Play();
            }

            owner.OnSwipe -= PlayAnimations;
        }
    }
}
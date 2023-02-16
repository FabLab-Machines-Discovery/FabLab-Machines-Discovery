using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

namespace Animations
{
    public class TextWipeAnimation : TextAnimation<float>
    {
        [Tooltip("Method with which the wipe mask should be animated")]
        public Image.FillMethod wipeFillMethod;
        
        // Used to create a gameObject that has a Mask and Image component
        private GameObject _maskObject;
        private Sprite _maskSprite;

        private void OnValidate()
        {
            // Make sure desiredValue is equal to 1, since any other value doesn't look good in this context
            animationProps.desiredValue = 1;
        }

        protected override void Awake()
        {
            base.Awake();
            _maskSprite = Resources.Load<Sprite>("Sprites/square");
        }

        public override void PlayAnimation()
        {
            // Create the GameObject
            _maskObject = new GameObject("Text Wipe Mask", typeof(RectTransform));
            
            // Add mask component and disable mask graphic
            var maskComponent = _maskObject.AddComponent<Mask>();
            maskComponent.showMaskGraphic = false;
            
            // Add image component and set its position, size, and anchors to the same as the textMesh
            var maskImageComponent = _maskObject.AddComponent<Image>();
            maskImageComponent.rectTransform.anchorMax = textMesh.rectTransform.anchorMax;
            maskImageComponent.rectTransform.anchorMin = textMesh.rectTransform.anchorMin;
            maskImageComponent.rectTransform.anchoredPosition = textMesh.rectTransform.anchoredPosition;
            maskImageComponent.rectTransform.sizeDelta = textMesh.rectTransform.sizeDelta;
            
            // Set the image source, and fill properties for animation purposes
            maskImageComponent.sprite = _maskSprite;
            maskImageComponent.type = Image.Type.Filled;
            maskImageComponent.fillMethod = wipeFillMethod;
            maskImageComponent.fillAmount = 0f;
            maskImageComponent.fillOrigin = wipeFillMethod == Image.FillMethod.Vertical ? 1 : 0;

            // Set the mask's parent to be the textMesh's current parent, then make the textMesh a child of the mask
            maskImageComponent.rectTransform.SetParent(textMesh.rectTransform.parent, false);
            textMesh.rectTransform.SetParent(maskImageComponent.rectTransform);
            
            // Animate the mask's image fill amount to desiredValue, while applying provided duration and delay
            tween = maskImageComponent.DOFillAmount(animationProps.desiredValue, animationProps.duration)
                .SetDelay(animationProps.delay)
                .OnComplete(ResetAnimation);
        }

        public override void ResetAnimation()
        {
            // Set the textMesh's parent to the original parent, which is now the mask's parent
            textMesh.rectTransform.SetParent(_maskObject.GetComponent<Image>().rectTransform.parent);
            
            // Kill the tween and destroy the mask GameObject as it's no longer needed
            tween.Kill();
            Destroy(_maskObject); 
        }
    }
}
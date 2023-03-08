using System;
using TMPro;
using UnityEngine;
using UnityEngine.Localization;
using UnityEngine.UI;

namespace Popups
{
    [Serializable] public class PopupColors
    {
        public Color generalColor;
        public Color useInstructionColor;
        public Color technicalColor;
        public Color safetyRiskColor;

        // Get a color depending on type of the popup
        public Color GetColor(PopupType type)
        {
            switch (type)
            {
                case PopupType.General:
                    return generalColor;
                case PopupType.UseInstruction:
                    return useInstructionColor;
                case PopupType.Technical:
                    return technicalColor;
                case PopupType.SafetyRisk:
                    return safetyRiskColor;
                default:
                    return Color.white;
            }
        }
    }
    public class PopupInfoUI : MonoBehaviour
    {
        // Instance for Singleton pattern
        public static PopupInfoUI Instance { get; private set; }

        [Tooltip("Container of the title text")]
        public Image titleContainer;
        
        [Tooltip("Alpha of the color applied to the container")]
        [Range(0, 1)] public float titleContainerAlpha;
        
        public TextMeshProUGUI title;
        public TextMeshProUGUI information;
        public PopupColors popupColors;
        
        // Used to retrieve the translated/localized strings depending on given reference
        private LocalizedString _information;
        // Name of the localized string table
        [SerializeField] private string stringTableReference;
        
        // Singleton Pattern
        private void Awake()
        {
            if (Instance != null && Instance != this)
            {
                Destroy(this);
            }
            else
            {
                _information = new LocalizedString();
                Instance = this;
            }
        }

        // Used to update the information's text by retrieving the given localized string's value
        private void UpdateText(string reference)
        {
            _information.TableReference = stringTableReference;
            _information.TableEntryReference = reference;
            information.text = _information.GetLocalizedString();
        }

        // Used to update the colors of the information's text and the title container depending on the clicked popup
        private void UpdateColor(Color color)
        {
            titleContainer.color = new Color(color.r, color.g, color.b, titleContainerAlpha);
            information.color = color;
        }

        // Called by the popup class
        public void DisplayPopupInfo(string reference, PopupType type)
        {
            UpdateText(reference);
            UpdateColor(popupColors.GetColor(type));
        }
    }
}
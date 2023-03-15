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
        public Color defaultColor;

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
                    return defaultColor;
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
        
        [Tooltip("Title text component")]
        public TextMeshProUGUI title;
        
        [Tooltip("Information text component")]
        public TextMeshProUGUI information;
        
        [Tooltip("Colors applied to text component and title container when a popup is clicked")]
        public PopupColors popupColors;
        
        // Used to retrieve the translated/localized strings depending on given reference
        private LocalizedString _information;
        
        [Tooltip("Name of the localized string table")]
        [SerializeField] private string stringTableReference;
        
        [Tooltip("Reference to the default localized string")]
        [SerializeField] private string defaultReference;
        
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

        private void Start()
        {
            UpdateText();
        }

        // Update the text component to the default localized string's value
        private void UpdateText()
        {
            _information.TableReference = stringTableReference;
            _information.TableEntryReference = defaultReference;
            information.text = _information.GetLocalizedString();
        }

        // Update the text component by retrieving the given localized string's value
        private void UpdateText(string reference)
        {
            _information.TableReference = stringTableReference;
            _information.TableEntryReference = reference;
            information.text = _information.GetLocalizedString();
        }

        //Update the colors of the text component and the title container depending on the clicked popup
        private void UpdateColor(Color color)
        {
            titleContainer.color = new Color(color.r, color.g, color.b, titleContainerAlpha);
            information.color = color;
        }

        /// <summary>
        /// Displays the text of the localized string using its reference.
        /// This is mainly called by the <see cref="Popup"/> class to display its content when it's clicked.
        /// </summary>
        /// <param name="reference">Reference of the localized string</param>
        /// <param name="type">Type of the popup</param>
        public void DisplayPopupInfo(string reference, PopupType type)
        {
            UpdateText(reference);
            UpdateColor(popupColors.GetColor(type));
        }
    }
}